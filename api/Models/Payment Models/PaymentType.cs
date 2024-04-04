using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class PaymentType
{
    [Key]
    public int Id { get; set; }
    public string PaymentName { get; set; }
    public ICollection<UserPaymentMethod> UserPaymentMethods { get; set; }
}