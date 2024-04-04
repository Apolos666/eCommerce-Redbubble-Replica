using System.ComponentModel.DataAnnotations;

namespace api.DTOs.IdentityDTOs;

public class UserRegister
{
    [Required]
    [EmailAddress]
    public string UserEmail { get; set; }
    [Required]
    [Phone]
    public string UserPhone { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string UserName { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}