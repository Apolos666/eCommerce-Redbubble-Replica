using api.DTOs.ProductSizeVariationDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ProductSizeVariationAutoMapperConfig : Profile
{
    public ProductSizeVariationAutoMapperConfig()
    {
        CreateMap<ProductSizeVariation, GetProductSizeVariation>();
        CreateMap<ProductSizeVariation, ProductSizeVariationDTO>();
        CreateMap<AddProductSizeVariation, ProductSizeVariation>();
    }
}