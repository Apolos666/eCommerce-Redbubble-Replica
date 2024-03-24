using api.DTOs.ProductAttributeOptionDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ProductAttributeOptionAutoMapperConfig : Profile
{
    public ProductAttributeOptionAutoMapperConfig()
    {
        CreateMap<ProductAttributeOption, GetProductAttributeOption>();
        CreateMap<ProductAttributeOption, ProductAttributeOptionDTO>();
        CreateMap<AddProductAttributeOption, ProductAttributeOption>();
    }
}