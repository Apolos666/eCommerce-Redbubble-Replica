using api.DTOs.SizeCategoryDTOs;

namespace api.DTOs.SizeOptionDTOs;

public class GetSizeOption
{
    public string SizeName { get; set; }
    public int SortOrder { get; set; }
    public int SizeCategoryId { get; set; }
    public SizeCategoryDTO SizeCategory { get; set; }
}