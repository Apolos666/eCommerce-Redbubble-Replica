using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class Country
{
    [Key]
    public int Id { get; set; }
    public string CountryName { get; set; }
    public ICollection<AddressModel> AddressModels { get; set; }
}