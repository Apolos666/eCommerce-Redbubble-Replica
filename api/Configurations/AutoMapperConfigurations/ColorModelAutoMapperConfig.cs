using api.DTOs.ColorModelDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class ColorModelAutoMapperConfig : Profile
{
    public ColorModelAutoMapperConfig()
    {
        CreateMap<ColorModel, GetColorModel>();
        CreateMap<GetColorModel, ColorModel>();
        CreateMap<AddColorModel, ColorModel>();
        CreateMap<UpdateColorModelHex, ColorModel>();
        CreateMap<UpdateColorModelName, ColorModel>();
    }
}