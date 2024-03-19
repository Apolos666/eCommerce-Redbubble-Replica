using api.DTOs.ColorModelDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ColorModelAutoMapperConfig : Profile
{
    public ColorModelAutoMapperConfig()
    {
        CreateMap<ColorModel, GetColorModel>();
        CreateMap<AddColorModel, ColorModel>();
    }
}