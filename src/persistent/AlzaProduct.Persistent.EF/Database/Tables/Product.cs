using System.ComponentModel.DataAnnotations;
using AlzaProduct.Core.Interfaces.Product;

namespace AlzaProduct.Persistent.EF.Database.Tables;

public class Product : IProduct
{
    public required int Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string Name { get; set; }

    [Required]
    [StringLength(100)]
    public required string ImgUri { get; set; }

    [Required]
    public required decimal Price { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }
}
