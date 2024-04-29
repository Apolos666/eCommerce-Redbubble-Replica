using Azure;
using Azure.Storage.Blobs;

namespace api.Services.AzureServices.BlobStrorage;

public class BlobServices : IBlobServices
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobServices(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }
    
    public async Task<BlobContainerClient> CreateSampleContainerAsync()
    {
        // Name the sample container based on new GUID to ensure uniqueness.
        // The container name must be lowercase.
        string containerName = "container-" + Guid.NewGuid();

        try
        {
            // Create the container
            BlobContainerClient container = await _blobServiceClient.CreateBlobContainerAsync(containerName);

            if (await container.ExistsAsync())
            {
                Console.WriteLine("Created container {0}", container.Name);
                return container;
            }
        }
        catch (RequestFailedException e)
        {
            Console.WriteLine("HTTP error code {0}: {1}",
                e.Status, e.ErrorCode);
            Console.WriteLine(e.Message);
        }

        return null;
    }

    public void CreateRootContainerAsync()
    {
        try
        {
            // Create the root container or handle the exception if it already exists
            BlobContainerClient container =  _blobServiceClient.CreateBlobContainer("$root");

            if (container.Exists())
            {
                Console.WriteLine("Created root container.");
            }
        }
        catch (RequestFailedException e)
        {
            Console.WriteLine("HTTP error code {0}: {1}",
                e.Status, e.ErrorCode);
            Console.WriteLine(e.Message);
        }
    }

    public async Task DeleteSampleContainerAsync(string containerName)
    {
        BlobContainerClient container = _blobServiceClient.GetBlobContainerClient(containerName);

        try
        {
            // Delete the specified container and handle the exception.
            await container.DeleteAsync();
        }
        catch (RequestFailedException e)
        {
            Console.WriteLine("HTTP error code {0}: {1}",
                e.Status, e.ErrorCode);
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}