using api.DTOs.ProductCategoryDTOs;

namespace api.Repositories.ProductCategory;

public interface IProductCategoryRepository
{
    Task<List<GetProductCategory>> GetAll();
}