using api.Models.Azure.Azure_Blob_Storage;
using Azure.Storage.Blobs;

namespace api.Services.AzureServices.BlobStrorage;

public interface IBlobServices
{
    Task<string> UploadBlobFileAsync(string blobContainerName ,string filePath, string fileName);
    Task<List<string>> ListBlobsAsync();
    Task<BlobObject> GetBlobFileAsync(string blobContainerName, string url);
    void DeleteBlob(string path);
}