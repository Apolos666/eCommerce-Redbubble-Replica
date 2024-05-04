using api.Data;
using api.DTOs.User_DTOs.UserImageDTOs;
using api.Helper;
using api.Models.Azure.Azure_Blob_Storage;
using api.Models.Identity;
using api.Repositories.User_Repositories.UserImage;
using Microsoft.AspNetCore.Identity;

namespace api.Services.AzureServices.BlobStrorage.UserProfile;

public class UserProfileBlobServices : IUserProfileBlobServices
{
    private readonly UserManager<ApplicationIdentityUser> _userManager;
    private readonly ApplicationDbContext _dbContext;
    private readonly IUserImageRepository _userImageRepository;
    private readonly IBlobServices _blobServices;

    public UserProfileBlobServices(
        UserManager<ApplicationIdentityUser> userManager,
        ApplicationDbContext dbContext,
        IUserImageRepository userImageRepository,
        IBlobServices blobServices
        )
    {
        _userManager = userManager;
        _dbContext = dbContext;
        _userImageRepository = userImageRepository;
        _blobServices = blobServices;
    }
    
    public async Task<string> UploadProfileImageAsync(string userName, string filePath, string fileName)
    {
        var absolutePath = await _blobServices.UploadBlobFileAsync(
            AzureBlobContainerHelper.ContainerName.UserProfileImages,
            filePath, fileName);
        
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        await _userImageRepository.DeactiveAllProfileImagesAsync(user.Id);
        
        var userImage = new AddUserImage()
        {
            UserId = user.Id,
            ImageUrl = absolutePath,
            IsProfileImage = true
        };

        var result = await _userImageRepository.AddUserImageAsync(userImage);
        return result.ImageUrl;
    }

    public async Task<BlobObject?> GetProfileImageUrlAsync(string imageUrl)
    {
        var result = await _blobServices.GetBlobFileAsync(
            AzureBlobContainerHelper.ContainerName.UserProfileImages, imageUrl);

        return result;
    }
}