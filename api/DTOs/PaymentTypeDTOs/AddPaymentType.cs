using System.ComponentModel.DataAnnotations;

namespace api.DTOs.PaymentTypeDTOs;

public class AddPaymentType
{
    [Required]
    public string PaymentName { get; set; }
}