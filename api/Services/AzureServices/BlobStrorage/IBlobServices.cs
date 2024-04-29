using Azure.Storage.Blobs;

namespace api.Services.AzureServices.BlobStrorage;

public interface IBlobServices
{
    Task<BlobContainerClient> CreateSampleContainerAsync();
    void CreateRootContainerAsync();
    Task DeleteSampleContainerAsync(string containerName);
}