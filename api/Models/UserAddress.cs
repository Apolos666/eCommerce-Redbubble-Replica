using System.ComponentModel.DataAnnotations;
using api.Models.Identity;

namespace api.Models;

public class UserAddress
{
    public int IdentityUserId { get; set; }
    public ApplicationIdentityUser IdentityUser { get; set; }
    public int AddressModelId { get; set; }
    public AddressModel AddressModel { get; set; }
    [Required]
    public bool IsDefault { get; set; }
}