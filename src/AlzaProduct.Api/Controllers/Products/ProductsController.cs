using Microsoft.AspNetCore.Mvc;

namespace AlzaProduct.Api.Controllers.Products;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class ProductsController : ControllerBase
{
    //private readonly IProductRepository _repository;

    public ProductsController(/*IProductRepository repository*/)
    {
        //_repository = repository;
    }
  
    [HttpGet, MapToApiVersion("1.0")]
    public async Task<IActionResult> GetAllProductsV1()
    {
        //var products = await _repository.GetAllProducts(1, int.MaxValue);
        //return Ok(products);
        return Ok();
    }

    [HttpGet, MapToApiVersion("2.0")]
    public async Task<IActionResult> GetAllProductsV2(int pageNumber = 1, int pageSize = 10)
    {
        //var products = await _repository.GetAllProducts(pageNumber, pageSize);
        //return Ok(products);
        return Ok();
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetProductById(int id)
    {
        //var product = await _repository.GetProductById(id);
        //if (product == null) return NotFound();
        //return Ok(product);
        return Ok();
    }

    [HttpPut("{id}/description")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateProductDescription(int id, [FromBody] string description)
    {
        //await _repository.UpdateProductDescription(id, description);
        //return NoContent();
        return Ok();
    }
}

