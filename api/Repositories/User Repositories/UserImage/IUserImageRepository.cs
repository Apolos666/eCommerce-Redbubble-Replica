using api.DTOs.User_DTOs.UserImageDTOs;

namespace api.Repositories.User_Repositories.UserImage;

public interface IUserImageRepository
{
    Task<GetUserImage> AddUserImageAsync(AddUserImage addUserImage);
    Task<List<string>> GetAllProfileImagesAsync(string userName);
    Task<string> GetCurrentActiveProfileImageUrlAsync(string userName);
    Task<bool> DeactiveAllProfileImagesAsync(string userId);
    Task<bool> SetActiveProfileImageAsync(string userName, string imageUrl);
}