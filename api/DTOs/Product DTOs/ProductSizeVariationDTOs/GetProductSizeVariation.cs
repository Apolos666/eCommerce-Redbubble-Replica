using api.DTOs.ProductItemDTOs;
using api.DTOs.SizeOptionDTOs;
using api.Models;

namespace api.DTOs.ProductSizeVariationDTOs;

public class GetProductSizeVariation
{
    public int ProductItemId { get; set; }
    public ProductItemDTO ProductItem { get; set; }
    public int SizeOptionsId { get; set; }
    public SizeOptionDTO SizeOption { get; set; }
    public int QuantityInStock { get; set; }
}