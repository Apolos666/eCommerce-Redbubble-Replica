using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DefaultNamespace;

[Table("SizeOptions")]
public class SizeOption
{
    public int Id { get; set; }
    [Required]
    public string SizeName { get; set; }
    [Required]
    public int SortOrder { get; set; }
    public int SizeCategoryId { get; set; }
    public SizeCategory SizeCategory { get; set; }
    public ICollection<ProductSizeVariation> ProductSizeVariations { get; set; }
}