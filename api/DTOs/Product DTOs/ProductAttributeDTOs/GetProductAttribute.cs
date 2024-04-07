using api.DTOs.ProductAttributeOptionDTOs;
using api.DTOs.ProductDTOs;

namespace api.DTOs.ProductAttributeDTOs;

public class GetProductAttribute
{
    public int ProductId { get; set; }
    public ProductDTO Product { get; set; }
    public int ProductAttributeOptionId { get; set; }
    public ProductAttributeOptionDTO ProductAttributeOption { get; set; }
}