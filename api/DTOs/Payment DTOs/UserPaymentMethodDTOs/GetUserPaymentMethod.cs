using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models;

namespace api.DTOs.Payment_DTOs.UserPaymentMethodDTOs;

public class GetUserPaymentMethod
{
    public int Id { get; set; }
    public string IdentityUserId { get; set; }
    public int PaymentTypeId { get; set; }
    public string Provider { get; set; }
    public string AccountNumber { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsDefault { get; set; }
}