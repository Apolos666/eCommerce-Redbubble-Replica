using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class ProductSizeVariation
{
    public int Id { get; set; }
    public int ProductItemId { get; set; }
    public ProductItem ProductItem { get; set; }
    public int SizeOptionsId { get; set; }
    public SizeOption SizeOption { get; set; }
    [Required]
    public int QuantityInStock { get; set; }
}