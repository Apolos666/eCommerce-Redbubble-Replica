namespace api.Models;

public class ProductAttributeOption
{
    public int Id { get; set; }
    public int AttributeOptionName { get; set; }
    public int ProductAttributeTypeId { get; set; }
    public ProductAttributeType ProductAttributeType { get; set; }
    public ICollection<ProductAttribute> ProductAttributes { get; set; }
}