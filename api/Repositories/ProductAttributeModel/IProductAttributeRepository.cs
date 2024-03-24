using api.DTOs.ProductAttributeDTOs;
using api.Models;
using api.Utilities;

namespace api.Repositories.ProductAttributeModel;

public interface IProductAttributeRepository
{
    Task<PagedResult<GetProductAttribute>> GetAll(QueryStringParameters productAttributeParameters);
    Task<List<GetProductAttribute>> GetAllByProductId(int productId);
    Task<List<GetProductAttribute>> GetAllByAttributeOptionId(int attributeOptionId);
    Task<GetProductAttribute> GetById(int id);
    Task<(Models.ProductAttribute, GetProductAttribute)> Create(AddProductAttribute addProductAttribute);
}