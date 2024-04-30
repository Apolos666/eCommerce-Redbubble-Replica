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

    public async Task<List<string>> ListBlobs()
    {
        var listBlob = new List<string>();

        await foreach (var blobItem in _blobContainerClient.GetBlobsAsync())
        {
            listBlob.Add(blobItem.Name);
        }

        return listBlob;
    }

    public async Task<BlobObject> GetBlobFile(string url)
    {
        var fileName = new Uri(url).Segments.LastOrDefault();

        try
        {
            var blobClient = _blobContainerClient.GetBlobClient(fileName);
            if (await blobClient.ExistsAsync())
            {
                BlobDownloadResult content = await blobClient.DownloadContentAsync();
                var downloadData = content.Content.ToStream();

                if (ImageExtensions.Contains(Path.GetExtension(fileName.ToUpperInvariant())))
                {
                    var extension = Path.GetExtension(fileName);
                    return new BlobObject { Content = downloadData, ContentType = "image/" + extension.Remove(0, 1) };
                }
                else
                {
                    return new BlobObject { Content = downloadData, ContentType = content.Details.ContentType };
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void DeleteBlob(string path)
    {
        var fileName = new Uri(path).Segments.LastOrDefault();
        var blobClient = _blobContainerClient.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
    }
}