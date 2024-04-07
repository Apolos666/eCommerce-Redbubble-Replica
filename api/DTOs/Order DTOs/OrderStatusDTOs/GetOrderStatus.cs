using api.Models;

namespace api.DTOs.Order_DTOs.OrderStatusDTOs;

public class GetOrderStatus
{
    public int Id { get; set; }
    public string Status { get; set; }
}