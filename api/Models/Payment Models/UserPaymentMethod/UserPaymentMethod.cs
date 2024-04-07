using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models.Identity;

namespace api.Models;

public class UserPaymentMethod
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [ForeignKey("IdentityUser")]
    public string IdentityUserId { get; set; }
    public ApplicationIdentityUser IdentityUser { get; set; }

    [Required]
    [ForeignKey("PaymentType")] 
    public int PaymentTypeId { get; set; }
    public PaymentType PaymentType { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Provider { get; set; }

    [Required]
    [StringLength(255)]
    public string AccountNumber { get; set; }

    [DataType(DataType.Date)]
    public DateTime? ExpiryDate { get; set; }

    [Required]
    public bool IsDefault { get; set; }

    public ICollection<ShopOrder> ShopOrders { get; set; }
}