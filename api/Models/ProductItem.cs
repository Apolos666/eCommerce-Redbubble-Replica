using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace DefaultNamespace;

[Table("ProductItems")]
public class ProductItem
{
    public int Id { get; set; }
    [Required]
    [Precision(18, 2)]
    public decimal OriginalPrice { get; set; }
    [Required]
    [Precision(18, 2)]
    public decimal SalePrice { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }    
    public int ColorId { get; set; }
    public ColorModel ColorModel { get; set; }
    public ICollection<ProductSizeVariation> ProductSizeVariations { get; set; }
    public ICollection<ProductImage> ProductImages { get; set; }
}