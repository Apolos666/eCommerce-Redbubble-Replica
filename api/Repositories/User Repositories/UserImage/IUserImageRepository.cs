using api.DTOs.User_DTOs.UserImageDTOs;

namespace api.Repositories.User_Repositories.UserImage;

public interface IUserImageRepository
{
    Task<GetUserImage> AddUserImage(AddUserImage addUserImage);
}