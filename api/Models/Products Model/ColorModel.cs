using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Table("Colors")]
public class ColorModel
{
    public int Id { get; set; }
    public string ColorName { get; set; }
    public string ColorHexCode { get; set; }
}