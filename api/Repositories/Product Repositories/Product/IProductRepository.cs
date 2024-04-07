using api.DTOs.ProductDTOs;

namespace api.Repositories.Product;

public interface IProductRepository
{
    Task<List<GetProduct>> GetAll();
    Task<GetProduct> GetProductById(int id);
    Task<(Models.Product, GetProduct)> AddProduct(AddProduct addProduct);
}