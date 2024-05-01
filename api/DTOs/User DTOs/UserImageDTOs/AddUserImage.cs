using System.ComponentModel.DataAnnotations;

namespace api.DTOs.User_DTOs.UserImageDTOs;

public class AddUserImage
{
    [Required]
    public string UserId { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public bool IsProfileImage { get; set; }
}