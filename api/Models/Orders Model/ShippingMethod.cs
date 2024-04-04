using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public class ShippingMethod
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }
    
    public ICollection<ShopOrder> ShopOrders { get; set; }
}