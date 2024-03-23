using api.DTOs.AttributeTypeModelDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ProductAttributeTypeAutoMapperConfig : Profile
{
    public ProductAttributeTypeAutoMapperConfig()
    {
        CreateMap<ProductAttributeType, GetProductAttributeType>();
        CreateMap<ProductAttributeType, ProductAttributeTypeDTO>();
        CreateMap<GetProductAttributeType, ProductAttributeType>();
        CreateMap<AddProductAttributeType, ProductAttributeType>();
        CreateMap<UpdateProductAttributeType, ProductAttributeType>();
    }
}