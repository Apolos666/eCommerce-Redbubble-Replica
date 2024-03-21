using api.DTOs.ProductCategoryDTOs;

namespace api.Repositories.ProductCategory;

public interface IProductCategoryRepository
{
    Task<List<GetProductCategory>> GetAll();
    Task<GetProductCategory> GetProductCategoryById(int id);
    Task<(Models.ProductCategory, GetProductCategory)> AddProductCategory(AddProductCategory addProductCategory);
}