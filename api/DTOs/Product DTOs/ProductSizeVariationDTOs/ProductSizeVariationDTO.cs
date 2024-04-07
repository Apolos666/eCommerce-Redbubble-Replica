namespace api.DTOs.ProductSizeVariationDTOs;

public class ProductSizeVariationDTO
{
    public int Id { get; set; }
    public int ProductItemId { get; set; }
    public int SizeOptionsId { get; set; }
    public int QuantityInStock { get; set; }
}