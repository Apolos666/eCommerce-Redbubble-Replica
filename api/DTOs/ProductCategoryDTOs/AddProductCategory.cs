using System.ComponentModel.DataAnnotations;

namespace api.DTOs.ProductCategoryDTOs;

public class AddProductCategory
{
    [Required]
    public string CategoryName { get; set; }
    [Required]
    public string CategoryImage { get; set; }
    [Required]
    public string CategoryDescription { get; set; }
    [Required]
    public int SizeCategoryId { get; set; }
    public int? ParentCategoryId { get; set; }
}