using api.DTOs.ProductItemDTOs;

namespace api.Repositories.ProductItem;

public interface IProductItemRepository
{
    Task<List<GetProductItem>> GetAll();
    Task<GetProductItem> GetProductItemById(int id);
    Task<(Models.ProductItem, GetProductItem)> AddProductItem(AddProductItem addProductItem);
}