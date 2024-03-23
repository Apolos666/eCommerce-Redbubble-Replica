using System.ComponentModel.DataAnnotations;

namespace api.DTOs.ProductSizeVariationDTOs;

public class AddProductSizeVariation
{
    [Required]
    public int ProductItemId { get; set; }
    [Required]
    public int SizeOptionsId { get; set; }
    [Required]
    public int QuantityInStock { get; set; }
}