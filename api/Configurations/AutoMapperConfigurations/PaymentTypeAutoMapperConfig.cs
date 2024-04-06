using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class PaymentTypeAutoMapperConfig : Profile
{
    public PaymentTypeAutoMapperConfig()
    {
        CreateMap<DTOs.PaymentTypeDTOs.AddPaymentType, Models.PaymentType>();
    }
}