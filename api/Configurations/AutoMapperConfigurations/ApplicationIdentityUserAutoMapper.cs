using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ApplicationIdentityUserAutoMapper : Profile
{
    public ApplicationIdentityUserAutoMapper()
    {
        CreateMap<Models.Identity.ApplicationIdentityUser, DTOs.IdentityDTOs.GetMe>();
    }
}