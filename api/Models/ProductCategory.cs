﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public int? ParentCategoryId { get; set; }
    public ProductCategory? ParentProductCategory { get; set; }
}