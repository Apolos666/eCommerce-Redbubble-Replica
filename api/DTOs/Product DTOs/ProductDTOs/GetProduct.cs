namespace api.DTOs.ProductDTOs;

public class GetProduct
{
    public string? ProductDescription { get; set; }
    public string ProductName { get; set; }
    public int ProductCategoryId { get; set; }
}