using api.Data;
using api.DTOs.User_DTOs.UserImageDTOs;
using api.Helper;
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
        
        var userImage = new AddUserImage()
        {
            UserId = user.Id,
            ImageUrl = absolutePath
        };

        var result = await _userImageRepository.AddUserImage(userImage);
        return result.ImageUrl;
    }
}