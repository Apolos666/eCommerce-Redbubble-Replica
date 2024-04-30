namespace api.Services.AzureServices.BlobStrorage;

public interface IUserProfileBlobServices
{
    Task<string> UploadProfileImageAsync(string userName, string filePath, string fileName);
}