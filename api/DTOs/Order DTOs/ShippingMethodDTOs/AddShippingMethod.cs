using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.DTOs.ShippingMethodDTOs;

public class AddShippingMethod
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }
}