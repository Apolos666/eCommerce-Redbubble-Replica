namespace api.Models;

public class ProductAttributeType
{
    public int Id { get; set; }
    public string AttributeName { get; set; }
    public ICollection<ProductAttributeOption> ProductAttributeOptions { get; set; }
}