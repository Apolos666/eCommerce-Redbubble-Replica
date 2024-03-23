using api.DTOs.SizeOptionDTOs;
using api.Models;
using AutoMapper;

namespace api.Configurations.AutoMapperConfigurations;

public class SizeOptionAutoMapperConfig : Profile
{
    public SizeOptionAutoMapperConfig()
    {
        CreateMap<SizeOption, GetSizeOption>();
        CreateMap<AddSizeOption, SizeOption>();
    }
}