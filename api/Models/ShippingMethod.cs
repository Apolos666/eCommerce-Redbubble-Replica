using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class ShippingMethod
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ICollection<ShopOrder> ShopOrders { get; set; }
}