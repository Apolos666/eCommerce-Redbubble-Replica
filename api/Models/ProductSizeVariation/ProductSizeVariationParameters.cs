namespace api.Models;

public class ProductSizeVariationParameters : QueryStringParameters
{
    public int? ProductItemId { get; set; }
    public int? SizeOptionsId { get; set; }
}