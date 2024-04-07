using api.DTOs.SizeOptionDTOs;

namespace api.Repositories.SizeOption;

public interface ISizeOptionRepository
{
    Task<List<GetSizeOption>> GetAll();
    Task<GetSizeOption> GetSizeOptionById(int id);
    Task<(Models.SizeOption, GetSizeOption)> AddSizeOption(AddSizeOption addSizeOption);
}