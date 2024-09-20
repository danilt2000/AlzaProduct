using AlzaProduct.Core.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;

namespace AlzaProduct.Api.Controllers.Products;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
    : ControllerBase
{
    [HttpGet, MapToApiVersion("1.0")]
    public IActionResult GetAllProducts()
    {
        try
        {
            var products = productRepository.GetList();

            return Ok(products);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to retrieve the list of products: {ErrorMessage}", ex.Message);

            return StatusCode(500, "An error occurred while retrieving the product list.");
        }
    }

    [HttpGet, MapToApiVersion("2.0")]
    public IActionResult GetAllProductsPagination(int pageNumber = 1, int pageSize = 10)
    {
        try
        {
            if (pageNumber <= 0)
                return BadRequest("Page number must be greater than 0.");

            if (pageSize <= 0)
                return BadRequest("Page size must be greater than 0.");

            var products = productRepository.GetListPagination(pageNumber, pageSize);

            return Ok(products);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to retrieve the list of products: {ErrorMessage}", ex.Message);

            return StatusCode(500, "An error occurred while retrieving the product list.");
        }
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    public IActionResult GetProductById(int id)
    {
        try
        {
            var product = productRepository.GetById(id);

            return Ok(product);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to retrieve the product: {ErrorMessage}", ex.Message);

            return StatusCode(500, "An error occurred while retrieving the product.");
        }
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

