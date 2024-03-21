using api.DTOs.ProductImage;

namespace api.Repositories.ProductImage;

public interface IProductImageRepository
{
    Task<List<GetProductImage>> GetAllProductImages();
    Task<GetProductImage> GetProductImageById(int id);
    Task<(Models.ProductImage , GetProductImage)> AddProductImage(AddProductImage addProductImage);
}