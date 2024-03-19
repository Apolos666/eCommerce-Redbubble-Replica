using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("Products")]
public class Product
{
    public int ProductId { get; set; }
    public string? ProductDescription { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public ICollection<ProductItem> ProductItems { get; set; }
    public ICollection<ProductAttribute> ProductAttributes { get; set; }
}