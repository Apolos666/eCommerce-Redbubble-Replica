using api.DTOs.AttributeTypeModelDTOs;
using api.Models;

namespace api.Repositories.AttributeTypeModel;

public interface IProductAttributeTypeRepository
{
    Task<List<GetProductAttributeType>> GetAll();
    Task<ProductAttributeType> Add(AddProductAttributeType addProductAttributeType);
    Task<GetProductAttributeType> GetById(int id);
    Task<GetProductAttributeType> Update(int id, UpdateProductAttributeType addProductAttributeType);
}