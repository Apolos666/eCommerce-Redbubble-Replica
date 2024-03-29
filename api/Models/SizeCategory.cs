﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("SizeCategories")]
public class SizeCategory
{
    public int Id { get; set; }
    [Required]
    public string SizeCategoryName { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
    public ICollection<SizeOption> SizeOptions { get; set; }
}