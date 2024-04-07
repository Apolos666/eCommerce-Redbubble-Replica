namespace api.DTOs.ProductDTOs;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string? ProductDescription { get; set; }
    public string ProductName { get; set; }
    public int ProductCategoryId { get; set; }
}