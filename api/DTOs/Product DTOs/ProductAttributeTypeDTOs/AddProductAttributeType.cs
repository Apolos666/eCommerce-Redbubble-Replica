using System.ComponentModel.DataAnnotations;

namespace api.DTOs.AttributeTypeModelDTOs;

public class AddProductAttributeType
{
    [Required]
    public string AttributeName { get; set; }
}