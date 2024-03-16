using api.DTOs.ProductCategoryDTOs;
using AutoMapper;
using DefaultNamespace;

namespace api.Configurations.AutoMapperConfigurations;

public class ProductCategoryAutoMapperConfig : Profile
{
    public ProductCategoryAutoMapperConfig()
    {
        CreateMap<ProductCategory, GetProductCategory>();
    }
}