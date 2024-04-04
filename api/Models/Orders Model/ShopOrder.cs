using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models.Identity;

namespace api.Models;

public class ShopOrder
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [ForeignKey("IdentityUser")]
    public string IdentityUserId { get; set; }
    public ApplicationIdentityUser IdentityUser { get; set; }
    
    [Required]
    [ForeignKey("PaymentMethod")] 
    public int PaymentMethodId { get; set; }
    public UserPaymentMethod PaymentMethod { get; set; }
    
    [Required]
    [ForeignKey("ShippingAddress")] 
    public int ShippingAdressId { get; set; }
    public AddressModel ShippingAddress { get; set; }
    
    [Required]
    [ForeignKey("ShippingMethod")]
    public int ShippingMethodId { get; set; }
    public ShippingMethod ShippingMethod { get; set; }
    
    [Required]
    [ForeignKey("OrderStatus")]
    public int OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime OrderDate { get; set; } = DateTime.Now;
    [Required]
    public int OrderTotal { get; set; }
    
    public ICollection<OrderLine> OrderLines { get; set; }
}