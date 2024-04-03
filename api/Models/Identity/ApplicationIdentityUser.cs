using Microsoft.AspNetCore.Identity;

namespace api.Models.Identity;

public class ApplicationIdentityUser : IdentityUser
{
    public ICollection<UserAddress> UserAddresses { get; set; }
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }
}