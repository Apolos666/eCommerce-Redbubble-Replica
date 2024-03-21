using api.DTOs.ProductCategoryDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ProductCategoryAutoMapperConfig : Profile
{
    public ProductCategoryAutoMapperConfig()
    {
        CreateMap<ProductCategory, GetProductCategory>();
        CreateMap<AddProductCategory, ProductCategory>();
    }
}