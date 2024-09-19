using System.ComponentModel.DataAnnotations;

namespace AlzaProduct.Persistent.EF.Database.Tables;

public class Product
{
    public required int Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string Name { get; set; }
}
