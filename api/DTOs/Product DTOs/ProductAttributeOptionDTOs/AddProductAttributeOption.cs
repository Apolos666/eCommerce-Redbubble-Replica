using System.ComponentModel.DataAnnotations;

namespace api.DTOs.ProductAttributeOptionDTOs;

public class AddProductAttributeOption
{
    [Required]
    public string AttributeOptionName { get; set; }
    [Required]
    public int ProductAttributeTypeId { get; set; }
}