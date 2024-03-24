using api.DTOs.ProductDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ProductAutoMapperConfig : Profile
{
    public ProductAutoMapperConfig()
    {
        CreateMap<Product, GetProduct>();
        CreateMap<Product, ProductDTO>();
        CreateMap<AddProduct, Product>();
    }
}