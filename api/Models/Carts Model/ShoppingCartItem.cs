using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class ShoppingCartItem
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("ShoppingCart")]
    public int cartId { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    
    [ForeignKey("ProductItem")]
    public int ProductItemId { get; set; }
    public ProductItem ProductItem { get; set; }
    
    public int Quantity { get; set; }
    
}