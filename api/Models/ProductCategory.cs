using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DefaultNamespace;

[Table("ProductCategories")]
public class ProductCategory
{
    public int ProductCategoryId { get; set; }
    [Required]
    [MaxLength(50)]
    public string CategoryName { get; set; }
    [Required]
    public string CategoryImage { get; set; }
    [Required]
    [MaxLength(250)]
    public string CategoryDescription { get; set; }
    
    public int SizeCategoryId { get; set; }
    public SizeCategory SizeCategory { get; set; }
    
    public int? ParentCategoryId { get; set; }
    public ProductCategory? ParentProductCategory { get; set; }
    
    public ICollection<Product> Products { get; set; }
}