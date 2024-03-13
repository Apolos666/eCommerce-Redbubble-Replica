using System.ComponentModel.DataAnnotations.Schema;

namespace DefaultNamespace;

[Table("ProductAttributes")]
public class ProductAttribute
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int ProductAttributeOptionId { get; set; }
    public ProductAttributeOption ProductAttributeOption { get; set; }
}