using AlzaProduct.Core.Interfaces.Product;
using AlzaProduct.Persistent.EF.Repositories;
using AlzaProduct.Persistent.EF.Tables;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AlzaProduct.Persistent.EF.IntegrationTests.Repositories;
public class ProductRepositoryIntegrationTests : IDisposable
{
    private readonly AppDbContext _dbContext;
    private readonly ProductRepository _repository;

    public ProductRepositoryIntegrationTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(TestDatabaseConfig.GetTestConnectionString())
            .Options;

        _dbContext = new AppDbContext(options);

        _repository = new ProductRepository(_dbContext);

        _dbContext.Products.ExecuteDelete();
    }

    [Fact]
    public void GetById_Returns_Product_When_Found()
    {
        var product = new Product { Name = "Test Product", ImgUri = "Test ImgUri", Price = 12M };

        _dbContext.Add(product);

        _dbContext.SaveChanges();

        var lastProduct = _dbContext.Products.OrderByDescending(p => p.Id).First();

        var result = _repository.GetById(lastProduct.Id);

        Assert.NotNull(result);
        Assert.NotNull(result?.Id);
        Assert.NotNull(result?.Name);
        Assert.NotNull(result?.ImgUri);
        Assert.NotNull(result?.Price);

        _dbContext.Products.ExecuteDelete();
    }

    [Fact]
    public void GetById_Throws_Exception_When_Not_Found()
    {
        Assert.Throws<InvalidOperationException>(() => _repository.GetById(int.MinValue));
    }

    [Fact]
    public void Save_Adds_New_Product()
    {
        var product = new Product { Name = "New Product", ImgUri = "img2.jpg", Price = 20M };

        _repository.Save(product);

        Assert.Equal(1, _dbContext.Products.Count());

        var savedProduct = _dbContext.Products.First();

        Assert.Equal(product.Name, savedProduct.Name);

        Assert.Equal(product.ImgUri, savedProduct.ImgUri);

        Assert.Equal(product.Price, savedProduct.Price);

        _dbContext.Products.ExecuteDelete();
    }

    [Fact]
    public void Update_Updates_Existing_Product()
    {
        var product = new Product { Name = "Test Product", ImgUri = "Test ImgUri", Price = 15M };

        _dbContext.Products.Add(product);

        _dbContext.SaveChanges();

        var lastProduct = _dbContext.Products.OrderByDescending(p => p.Id).First();

        var updatedProduct = new Product { Name = "Updated Product", ImgUri = "Updated ImgUri", Price = 25M };

        _repository.Update(lastProduct.Id, updatedProduct);

        var result = _dbContext.Products.First();

        Assert.Equal("Updated Product", result.Name);

        Assert.Equal("Updated ImgUri", result.ImgUri);

        Assert.Equal(25M, result.Price);

        _dbContext.Products.ExecuteDelete();
    }

    [Fact]
    public void Delete_Removes_Product()
    {
        var product = new Product { Name = "Test Product", ImgUri = "Test ImgUri", Price = 10M };

        _dbContext.Products.Add(product);

        _dbContext.SaveChanges();

        var lastProduct = _dbContext.Products.OrderByDescending(p => p.Id).First();

        _repository.Delete(lastProduct.Id);

        Assert.Empty(_dbContext.Products);

        _dbContext.Products.ExecuteDelete();
    }

    [Fact]
    public void GetList_Returns_All_Products()
    {
        var products = new List<Product>
            {
                new Product { Name = "Product 1", ImgUri = "img1.jpg", Price = 10M },
                new Product { Name = "Product 2", ImgUri = "img2.jpg", Price = 20M }
            };

        _dbContext.Products.AddRange(products);

        _dbContext.SaveChanges();

        var result = _repository.GetList();

        IEnumerable<IProduct> enumerableProducts = result.ToList();

        Assert.Equal(2, enumerableProducts.Count());

        Assert.Contains(enumerableProducts, p => p.Name == "Product 1");

        Assert.Contains(enumerableProducts, p => p.Name == "Product 2");

        _dbContext.Products.ExecuteDelete();
    }

    [Fact]
    public void GetListPagination_Returns_Correct_Page_Of_Products()
    {
        var products = new List<Product>
        {
            new Product { Name = "Product 1", ImgUri = "img1.jpg", Price = 10M },
            new Product { Name = "Product 2", ImgUri = "img2.jpg", Price = 20M },
            new Product { Name = "Product 3", ImgUri = "img3.jpg", Price = 30M },
            new Product { Name = "Product 4", ImgUri = "img4.jpg", Price = 40M },
            new Product { Name = "Product 5", ImgUri = "img5.jpg", Price = 50M }
        };

        _dbContext.Products.AddRange(products);

        _dbContext.SaveChanges();

        var pageNumber = 1;

        const int pageSize = 2;

        var result = _repository.GetListPagination(pageNumber, pageSize).ToList();

        Assert.Equal(2, result.Count);

        Assert.Equal("Product 1", result[0].Name);
        Assert.Equal("Product 2", result[1].Name);

        pageNumber = 2;
        result = _repository.GetListPagination(pageNumber, pageSize).ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal("Product 3", result[0].Name);
        Assert.Equal("Product 4", result[1].Name);

        pageNumber = 3;
        result = _repository.GetListPagination(pageNumber, pageSize).ToList();

        Assert.Single(result);
        Assert.Equal("Product 5", result[0].Name);

        _dbContext.Products.ExecuteDelete();
    }

    public void Dispose()
    {
        _dbContext.Products.ExecuteDelete();
    }
}
