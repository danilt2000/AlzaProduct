using AlzaProduct.Api.Controllers.Products;
using AlzaProduct.Api.UnitTests.Models;
using AlzaProduct.Core.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AlzaProduct.Api.UnitTests.Controllers.Products;
public class ProductsControllerUnitTests
{
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly ProductsController _controller;

    public ProductsControllerUnitTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        Mock<ILogger<ProductsController>> mockLogger = new();
        _controller = new ProductsController(_mockProductRepository.Object, mockLogger.Object);
    }

    [Fact]
    public void GetAllProducts_ReturnsOkResult_WithProductList()
    {
        var products = new List<IProduct> { new TestProduct() { Id = 1, Name = "Product1", ImgUri = "TestUri", Price = 12M } };

        _mockProductRepository.Setup(repo => repo.GetList()).Returns(products);

        var result = _controller.GetAllProducts();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetAllProducts_HandlesException_Returns500()
    {
        _mockProductRepository.Setup(repo => repo.GetList()).Throws(new InvalidDataException("Test exception"));

        var result = _controller.GetAllProducts();

        var statusCodeResult = Assert.IsType<ObjectResult>(result);

        Assert.Equal(500, statusCodeResult.StatusCode);

        Assert.Equal("An error occurred while retrieving the product list.", statusCodeResult.Value);
    }

    [Fact]
    public void GetProductById_ReturnsOkResult_WithProduct()
    {
        var product = new TestProduct() { Id = 1, Name = "Product1", ImgUri = "TestUri", Price = 12M };

        _mockProductRepository.Setup(repo => repo.GetById(1)).Returns(product);

        var result = _controller.GetProductById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);

        Assert.Equal(product, okResult.Value);
    }

    [Fact]
    public void GetProductById_HandlesException_Returns500()
    {
        _mockProductRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Throws(new InvalidDataException("Test exception"));

        var result = _controller.GetProductById(1);

        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
        Assert.Equal("An error occurred while retrieving the product.", statusCodeResult.Value);
    }

    [Fact]
    public void GetAllProductsPagination_ReturnsOkResult_WithPagedProducts()
    {
        var products = new List<IProduct> { new TestProduct() { Id = 1, Name = "Product1", ImgUri = "TestUri", Price = 12M } };

        _mockProductRepository.Setup(repo => repo.GetListPagination(1, 10)).Returns(products);

        var result = _controller.GetAllProductsPagination(1, 10);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetAllProductsPagination_InvalidPageNumber_ReturnsBadRequest()
    {
        var result = _controller.GetAllProductsPagination(0, 10);

        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Page number must be greater than 0.", badRequestResult.Value);
    }

    [Fact]
    public void UpdateProductDescription_UpdatesProduct_ReturnsOk()
    {
        var product = new TestProduct() { Id = 1, Name = "Product1", ImgUri = "TestUri", Price = 12M };
        _mockProductRepository.Setup(repo => repo.GetById(1)).Returns(product);
        _mockProductRepository.Setup(repo => repo.Update(1, It.IsAny<IProduct>()));

        var result = _controller.UpdateProductDescription(1, "New Description");

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("the product description was successfully updated", okResult.Value);
        _mockProductRepository.Verify(repo => repo.Update(1, It.IsAny<IProduct>()), Times.Once);
    }

    [Fact]
    public void UpdateProductDescription_HandlesException_Returns500()
    {
        _mockProductRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Throws(new InvalidDataException("Test exception"));

        var result = _controller.UpdateProductDescription(1, "New Description");

        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
        Assert.Equal("An error occurred while updating the product.", statusCodeResult.Value);
    }
}
