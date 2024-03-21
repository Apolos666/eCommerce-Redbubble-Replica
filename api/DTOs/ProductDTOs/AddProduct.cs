using System.ComponentModel.DataAnnotations;

namespace api.DTOs.ProductDTOs;

public class AddProduct
{
    [Required]
    public string? ProductDescription { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public int ProductCategoryId { get; set; }
}