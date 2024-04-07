using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ShippingMethodAutoMapperConfig : Profile
{
    public ShippingMethodAutoMapperConfig()
    {
        CreateMap<Models.ShippingMethod, DTOs.ShippingMethodDTOs.GetShippingMethod>();
        CreateMap<DTOs.ShippingMethodDTOs.AddShippingMethod, Models.ShippingMethod>();
    }
}