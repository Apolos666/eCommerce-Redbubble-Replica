using api.DTOs.ProductAttributeDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ProductAttributeAutoMapperConfig : Profile
{
    public ProductAttributeAutoMapperConfig()
    {
        CreateMap<ProductAttribute, GetProductAttribute>();
        CreateMap<AddProductAttribute, ProductAttribute>();
    }
}