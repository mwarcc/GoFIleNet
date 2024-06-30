using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFileNet.GoFileNet.Entities
{
    public class UploadData
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("downloadPage")]
        public string DownloadPage { get; set; }

        [JsonProperty("fileId")]
        public string FileId { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("guestToken")]
        public string GuestToken { get; set; }

        [JsonProperty("md5")]
        public string Md5 { get; set; }

        [JsonProperty("parentFolder")]
        public string ParentFolder { get; set; }
    }
}
