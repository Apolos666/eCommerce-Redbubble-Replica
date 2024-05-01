using api.Models.Azure.Azure_Blob_Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace api.Services.AzureServices.BlobStrorage;

public class BlobServices : IBlobServices
{
    private readonly BlobServiceClient _blobServiceClient;
    private BlobContainerClient _blobContainerClient;
    public static readonly List<string> ImageExtensions =
        [".JPG", ".JPEG", ".PNG", ".GIF", ".BMP", ".TIFF", ".SVG", ".WEBP"];

    public BlobServices(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
        _blobContainerClient = blobServiceClient.GetBlobContainerClient("user-profile-images");
    }
    
    public async Task<string> UploadBlobFileAsync(string blobContainerName ,string filePath, string fileName)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);
        var status = await blobClient.UploadAsync(filePath);

        return blobClient.Uri.AbsoluteUri;
    }

    public async Task<List<string>> ListBlobsAsync()
    {
        var listBlob = new List<string>();

        await foreach (var blobItem in _blobContainerClient.GetBlobsAsync())
        {
            listBlob.Add(blobItem.Name);
        }

        return listBlob;
    }

    public async Task<BlobObject> GetBlobFileAsync(string blobContainerName, string url)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
        var fileName = Uri.UnescapeDataString(new Uri(url).Segments.LastOrDefault());
        var blobClient = blobContainerClient.GetBlobClient(fileName);
        var blobDownloadInfo = await blobClient.DownloadAsync();
        return new BlobObject(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.ContentType);
    }

    public async void DeleteBlob(string path)
    {
        var fileName = new Uri(path).Segments.LastOrDefault();
        var blobClient = _blobContainerClient.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
    }
}