using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.DTOs.ProductItemDTOs;

public class AddProductItem
{
    [Required]
    [Precision(18, 2)]
    public decimal OriginalPrice { get; set; }
    [Required]
    [Precision(18, 2)]
    public decimal SalePrice { get; set; }
    [Required]
    public int ProductId { get; set; }   
    [Required]
    public int ColorId { get; set; }
}