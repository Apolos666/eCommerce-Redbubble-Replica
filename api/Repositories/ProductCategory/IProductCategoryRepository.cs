using api.DTOs.ProductCategoryDTOs;
using api.Models;
using api.Utilities;

namespace api.Repositories.ProductCategory;

public interface IProductCategoryRepository
{
    Task<PagedResult<GetProductCategory>> GetAll(ProductCategoryParameters queryParameters);
    Task<GetProductCategory> GetProductCategoryById(int id);
    Task<(Models.ProductCategory, GetProductCategory)> AddProductCategory(AddProductCategory addProductCategory);
}