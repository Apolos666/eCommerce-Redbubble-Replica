using api.DTOs.Payment_DTOs.UserPaymentMethodDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class UserPaymentMethodAutoMapperConfig : Profile
{
    public UserPaymentMethodAutoMapperConfig()
    {
        CreateMap<UserPaymentMethod, GetUserPaymentMethod>();
        CreateMap<AddUserPaymentMethod, UserPaymentMethod>();
    }
}