using System.ComponentModel.DataAnnotations;

namespace api.DTOs.ProductImage;

public class AddProductImage
{
    [Required]
    public string ImageFileName { get; set; }
    [Required]
    public int ProductItemId { get; set; }
}