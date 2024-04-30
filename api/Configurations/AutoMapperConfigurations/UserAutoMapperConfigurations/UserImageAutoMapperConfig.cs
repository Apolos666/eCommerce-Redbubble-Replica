using api.DTOs.User_DTOs.UserImageDTOs;
using api.Models.Identity;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations.UserAutoMapperConfigurations;

public class UserImageAutoMapperConfig : Profile
{
    public UserImageAutoMapperConfig()
    {
        CreateMap<UserImage, GetUserImage>();
        CreateMap<AddUserImage, UserImage>();
    }
}