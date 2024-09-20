using AlzaProduct.Core.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;

namespace AlzaProduct.Api.Controllers.Products;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class ProductsController(IProductRepository productRepository) : ControllerBase//Todo add logger 
{
    private readonly IProductRepository _productRepository = productRepository;

    [HttpGet, MapToApiVersion("1.0")]
    public IActionResult GetAllProducts()
    {
        var products = _productRepository.GetList();

        return Ok(products);
    }

    [HttpGet, MapToApiVersion("2.0")]
    public IActionResult GetAllProductsPagination(int pageNumber = 1, int pageSize = 10)
    {
        //var products = await _productRepository.GetAllProducts(pageNumber, pageSize);
        //return Ok(products);
        return Ok();
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetProductById(int id)
    {
        //var product = await _productRepository.GetProductById(id);
        //if (product == null) return NotFound();
        //return Ok(product);
        return Ok();
    }

    [HttpPut("{id}/description")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateProductDescription(int id, [FromBody] string description)
    {
        //await _productRepository.UpdateProductDescription(id, description);
        //return NoContent();
        return Ok();
    }
}

