using AlzaProduct.Core.Interfaces.Product;

namespace AlzaProduct.Api.UnitTests.Models;
internal class TestProduct : IProduct
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string ImgUri { get; set; }

    public required decimal Price { get; set; }

    public string? Description { get; set; }
}
