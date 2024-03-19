using System.ComponentModel.DataAnnotations;

namespace api.DTOs.ColorModelDTOs;

public class UpdateColorModelHex
{
    [Required]
    [RegularExpression("^#[0-9A-Fa-f]{6}$", ErrorMessage = "ColorHexCode must start with '#' followed by 6 hexadecimal digits.")]
    public string ColorHexCode { get; set; }
}