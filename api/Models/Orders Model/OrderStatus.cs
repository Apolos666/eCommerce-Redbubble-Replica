using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class OrderStatus
{
    [Key]
    public int Id { get; set; }
    public string Status { get; set; }
    public ICollection<ShopOrder> ShopOrders { get; set; }
}