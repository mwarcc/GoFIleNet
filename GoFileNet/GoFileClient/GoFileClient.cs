using GoFileNet.GoFileNet.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoFileNet.GoFileNet
{
    public class GofileClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _token;
        private readonly string _accountId;

        public GofileClient(string token, string accountId)
        {
            _token = token ?? throw new ArgumentNullException(nameof(token));
            _accountId = accountId ?? throw new ArgumentNullException(nameof(accountId));
            _httpClient = new HttpClient();
        }

        public async Task<AccountInfo> GetAccountInfoAsync()
        {
            string url = $"https://api.gofile.io/accounts/{_accountId}";
            SetAuthorizationHeader();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AccountInfo>(jsonResponse);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to get account info.", ex);
            }
        }

        public async Task<ServerInfo> GetServerAsync()
        {
            const string url = "https://api.gofile.io/getServer";
            SetAuthorizationHeader();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var serverResponse = JsonConvert.DeserializeObject<ServerResponse>(jsonResponse);
                return new ServerInfo { Name = serverResponse.Data.Server };
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to get server info.", ex);
            }
        }

        public async Task<UploadResponse> UploadFileAsync(string filePath, string folderId)
        {
            var serverInfo = await GetServerAsync();
            string url = $"https://{serverInfo.Name}.gofile.io/contents/uploadFile";

            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(folderId), "folderId");

                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        var fileContent = new StreamContent(fileStream);
                        content.Add(fileContent, "file", Path.GetFileName(filePath));

                        SetAuthorizationHeader();

                        HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                        response.EnsureSuccessStatusCode();

                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<UploadResponse>(jsonResponse);
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception("Failed to upload file.", ex);
                }
                catch (IOException ex)
                {
                    throw new Exception("Failed to read file for upload.", ex);
                }
            }
        }

        private void SetAuthorizationHeader()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

    }
}
