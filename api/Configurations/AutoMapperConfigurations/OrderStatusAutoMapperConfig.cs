using api.DTOs.Order_DTOs.OrderStatusDTOs;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class OrderStatusAutoMapperConfig : Profile
{
    public OrderStatusAutoMapperConfig()
    {
        CreateMap<Models.OrderStatus, GetOrderStatus>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        CreateMap<AddOrderStatus, Models.OrderStatus>();
    }
}