using api.DTOs.ProductImage;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ProductImageAutoMapperConfig : Profile
{
    public ProductImageAutoMapperConfig()
    {
        CreateMap<ProductImage, GetProductImage>();
        CreateMap<AddProductImage, ProductImage>();
    }
}