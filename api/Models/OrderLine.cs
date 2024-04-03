using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class OrderLine
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("ProductItem")]
    public int ProductItemId { get; set; }
    public ProductItem ProductItem { get; set; }
    
    [Required]
    [ForeignKey("ShopOrder")]
    public int ShopOrderId { get; set; }
    public ShopOrder ShopOrder { get; set; }

    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }

    public ICollection<UserReview> UserReviews { get; set; }
}