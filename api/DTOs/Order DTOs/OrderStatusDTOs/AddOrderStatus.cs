using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.DTOs.Order_DTOs.OrderStatusDTOs;

public class AddOrderStatus
{
    [Required]
    [Range(1, 5, ErrorMessage = "Status must be between 1 and 5")]
    public OrderStatusEnum Status { get; set; }
}