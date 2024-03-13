using System.ComponentModel.DataAnnotations.Schema;

namespace DefaultNamespace;

[Table("Colors")]
public class ColorModel
{
    public int Id { get; set; }
    public string ColorName { get; set; }
}