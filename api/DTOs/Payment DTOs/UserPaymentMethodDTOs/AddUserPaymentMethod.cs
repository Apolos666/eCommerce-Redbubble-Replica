using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Payment_DTOs.UserPaymentMethodDTOs;

public class AddUserPaymentMethod
{
    [Required]
    public string IdentityUserId { get; set; }

    [Required]
    public int PaymentTypeId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Provider { get; set; }

    [Required]
    [StringLength(255)]
    public string AccountNumber { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime? ExpiryDate { get; set; }

    [Required]
    public bool IsDefault { get; set; }
}