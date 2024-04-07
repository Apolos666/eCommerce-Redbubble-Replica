using System.ComponentModel.DataAnnotations;

namespace api.DTOs.AttributeTypeModelDTOs;

public class UpdateProductAttributeType
{
    [Required]
    public string AttributeName { get; set; }
}