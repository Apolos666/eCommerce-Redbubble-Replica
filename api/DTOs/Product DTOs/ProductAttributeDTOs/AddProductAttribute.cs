using System.ComponentModel.DataAnnotations;

namespace api.DTOs.ProductAttributeDTOs;

public class AddProductAttribute
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int ProductAttributeOptionId { get; set; }
}