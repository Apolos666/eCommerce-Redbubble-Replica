using api.DTOs.SizeCategoryDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class SizeCategoryAutoMapperConfig : Profile
{
    public SizeCategoryAutoMapperConfig()
    {
        CreateMap<SizeCategory, GetSizeCategory>();
        CreateMap<SizeCategory, SizeCategoryDTO>();
        CreateMap<AddSizeCategory, SizeCategory>();
    }
}