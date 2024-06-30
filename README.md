# GoFIleNet
GoFileNet is a .NET library for easy interaction with the unofficial GoFile.io API. This library allows developers to upload files, retrieve account information, and manage server interactions seamlessly within their .NET applications.

# Features
- Upload files to GoFile.io
- Retrieve account information
- Get server details and status
- Manage upload responses
- Manage folders and files (soon)

# Usage example
Make sure at first to import the using:
```cs
using GoFileNet.GoFileNet;
```
Define the class instance:
```cs
 GofileClient gofileClient = new GofileClient("ccountToken", "accountId");
```
# Upload file to a folder
```cs
UploadResponse uploadRespons = await gofileClient.UploadFileAsync("filePath", "folderid");
```
