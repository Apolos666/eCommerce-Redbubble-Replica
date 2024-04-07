using api.DTOs.AttributeTypeModelDTOs;

namespace api.DTOs.ProductAttributeOptionDTOs;

public class GetProductAttributeOption
{
    public string AttributeOptionName { get; set; }
    public int ProductAttributeTypeId { get; set; }
    public ProductAttributeTypeDTO ProductAttributeType { get; set; }
}