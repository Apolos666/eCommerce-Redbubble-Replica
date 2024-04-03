using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models.Identity;

namespace api.Models;

public class ShoppingCart
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("IdentityUser")]
    public string IdentityUserId { get; set; }
    public ApplicationIdentityUser IdentityUser { get; set; }
}