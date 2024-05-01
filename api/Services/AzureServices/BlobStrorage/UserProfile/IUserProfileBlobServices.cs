using api.Models.Azure.Azure_Blob_Storage;

namespace api.Services.AzureServices.BlobStrorage.UserProfile;

public interface IUserProfileBlobServices
{
    Task<string> UploadProfileImageAsync(string userName, string filePath, string fileName);
    Task<BlobObject> GetProfileImageUrlAsync(string imageUrl);
}