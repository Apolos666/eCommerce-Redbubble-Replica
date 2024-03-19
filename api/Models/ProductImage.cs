namespace api.Models;

public class ProductImage
{
    public int Id { get; set; }
    public string ImageFileName { get; set; }
    public int ProductItemId { get; set; }
    public ProductItem ProductItem { get; set; }
}