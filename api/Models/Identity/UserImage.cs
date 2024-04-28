using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Identity;

[Table("UserImages")]
public class UserImage
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("IdentityUser")]
    public string UserId { get; set; }
    public ApplicationIdentityUser IdentityUser { get; set; }
    public string ImageUrl { get; set; }
}