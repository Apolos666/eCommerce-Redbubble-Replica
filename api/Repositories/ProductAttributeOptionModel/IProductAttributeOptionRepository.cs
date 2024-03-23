using api.DTOs.ProductAttributeOptionDTOs;

namespace api.Repositories.ProductAttributeOptionModel;

public interface IProductAttributeOptionRepository
{
    Task<List<GetProductAttributeOption>> GetAll();
    Task<GetProductAttributeOption> GetProductAttributeOptionById(int id);
    Task<(Models.ProductAttributeOption, GetProductAttributeOption)> AddProductAttributeOption(AddProductAttributeOption addProductAttributeOption);
}