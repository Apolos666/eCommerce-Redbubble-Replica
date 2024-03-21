using api.DTOs.ProductItemDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ProductItemAutoMapperConfig : Profile
{
    public ProductItemAutoMapperConfig()
    {
        CreateMap<ProductItem, GetProductItem>();
        CreateMap<AddProductItem, ProductItem>();
    }
}