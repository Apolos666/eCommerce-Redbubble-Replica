using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class OrderStatus
{
    [Key]
    public int Id { get; set; }
    public OrderStatusEnum Status { get; set; }
    public ICollection<ShopOrder> ShopOrders { get; set; }
}

public enum OrderStatusEnum
{
    Pending = 1,
    Processing = 2,
    Shipped = 3,
    Delivered = 4,
    Cancelled = 5
}