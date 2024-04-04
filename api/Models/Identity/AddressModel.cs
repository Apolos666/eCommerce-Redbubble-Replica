using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class AddressModel
{
    [Key]
    public int Id { get; set; }
    [StringLength(20)]
    public string UnitNumber { get; set; }
    [StringLength(50)] 
    public string StreetNumber { get; set; }
    [StringLength(255)] 
    public string AddressLine1 { get; set; }
    [StringLength(255)] 
    public string AddressLine2 { get; set; }
    [Required]  
    public string City { get; set; }
    [Required]  
    public string Region { get; set; }
    public string PostalCode { get; set; }
    [ForeignKey("Country")]
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public ICollection<UserAddress> UserAddresses { get; set; }
}