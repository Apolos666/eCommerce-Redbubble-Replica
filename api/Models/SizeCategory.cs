using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DefaultNamespace;

[Table("SizeCategories")]
public class SizeCategory
{
    public int Id { get; set; }
    [Required]
    public string SizeCategoryName { get; set; }
}