using api.DTOs.ProductCategoryDTOs;
using api.Models;

namespace api.DTOs.SizeCategoryDTOs;

public class GetSizeCategory
{
    public string SizeCategoryName { get; set; }
    public ICollection<ProductCategoryDTO> ProductCategories { get; set; }
}