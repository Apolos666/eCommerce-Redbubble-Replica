using System.ComponentModel.DataAnnotations;

namespace api.DTOs.SizeCategoryDTOs;

public class AddSizeCategory
{
    [Required]
    public string SizeCategoryName { get; set; }
}