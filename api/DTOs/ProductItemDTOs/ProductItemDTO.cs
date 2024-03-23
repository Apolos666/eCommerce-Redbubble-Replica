namespace api.DTOs.ProductItemDTOs;

public class ProductItemDTO
{
    public int Id { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal SalePrice { get; set; }
    public int ProductId { get; set; }  
    public int ColorId { get; set; }
}