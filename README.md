# GoFIleNet
GoFileNet is a .NET library for easy interaction with the unofficial GoFile.io API. This library allows developers to upload files, retrieve account information, and manage server interactions seamlessly within their .NET applications.

# Features
- Upload files to GoFile.io
- Retrieve account information
- Get server details and status
- Manage upload responses
- Manage folders and files (soon)

# Usage example
```cs
using GoFileNet.GoFileNet;
```

```cs
 static async Task Main(string[] args)
 {
     GofileClient gofileClient = new GofileClient("accountToken", "accountIdentifier");
     AccountInfo accountInfo = await gofileClient.GetAccountInfoAsync();
     Console.WriteLine(accountInfo.Data.Email);

     UploadResponse uploadResponse = await gofileClient.UploadFileAsync("filePath", "folderId");
     Console.WriteLine(uploadResponse.Data.FileId);
 }
```
