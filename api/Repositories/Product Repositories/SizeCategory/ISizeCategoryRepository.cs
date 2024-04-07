using api.DTOs.SizeCategoryDTOs;

namespace api.Repositories.SizeCategory;

public interface ISizeCategoryRepository
{
    Task<List<GetSizeCategory>> GetAll();
    Task<GetSizeCategory> GetSizeCategoryById(int id);
    Task<(Models.SizeCategory, GetSizeCategory)> AddSizeCategory(AddSizeCategory addSizeCategory);
}