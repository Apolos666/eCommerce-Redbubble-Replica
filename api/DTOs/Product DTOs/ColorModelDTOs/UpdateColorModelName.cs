using System.ComponentModel.DataAnnotations;

namespace api.DTOs.ColorModelDTOs;

public class UpdateColorModelName
{
    [Required]
    public string ColorName { get; set; }
}