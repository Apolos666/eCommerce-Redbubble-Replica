namespace api.DTOs.ProductCategoryDTOs;

public class GetProductCategory
{
    public string CategoryName { get; set; }
    public string CategoryImage { get; set; }
    public string CategoryDescription { get; set; }
    public int SizeCategoryId { get; set; }
    public int? ParentCategoryId { get; set; }
}