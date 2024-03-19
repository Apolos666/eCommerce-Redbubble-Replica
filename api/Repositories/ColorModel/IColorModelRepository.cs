using api.DTOs.ColorModelDTOs;

namespace api.Repositories.ColorModel;

public interface IColorModelRepository
{
    Task<List<GetColorModel>> GetAll();
    Task<GetColorModel> GetColorByName(string colorName);
    Task<GetColorModel> GetColorByColorHex(string ColorHexCode);
    Task<GetColorModel> Add(AddColorModel addColorModel);
    Task<GetColorModel> Update(UpdateColorModel updateColorModel);
}