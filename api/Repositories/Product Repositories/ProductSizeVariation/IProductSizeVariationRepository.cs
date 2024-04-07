using api.DTOs.ProductSizeVariationDTOs;
using api.Models;
using api.Utilities;

namespace api.Repositories.ProductSizeVariation;

public interface IProductSizeVariationRepository
{
    Task<PagedResult<GetProductSizeVariation>> GetAll(QueryStringParameters productSizeVariationParameters);
    Task<List<GetProductSizeVariation>> GetAllByProductItemId(int productItemId);
    Task<List<GetProductSizeVariation>> GetAllBySizeOptionsId(int sizeOptionsId);
    Task<GetProductSizeVariation> GetById(int id);
    Task<(Models.ProductSizeVariation, GetProductSizeVariation)> Create(AddProductSizeVariation addProductSizeVariation);
}