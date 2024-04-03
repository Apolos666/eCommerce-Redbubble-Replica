using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public class UserReview
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("IdentityUser")]
    public string IdentityUserId { get; set; }
    public ApplicationIdentityUser IdentityUser { get; set; }
    
    [Required]
    [ForeignKey("OrderLine")] 
    public int OrderLineId { get; set; }
    public OrderLine OrderLine { get; set; }

    [Required]
    [Range(0, 5)]
    [Precision(3, 2)]
    public decimal Rating { get; set; }

    public string? Comment { get; set; }
}