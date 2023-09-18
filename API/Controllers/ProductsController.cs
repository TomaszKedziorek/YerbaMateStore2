using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private readonly IGenericRepository<Product> _productRepository;

  public ProductsController(IGenericRepository<Product> productRepository)
  {
    _productRepository = productRepository;
  }

  [HttpGet]
  public async Task<ActionResult<List<Product>>> GetProducts()
  {
    var products = await _productRepository.GetAllAsync();
    return Ok(products);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Product>> GetProduct(int id)
  {
    return await _productRepository.GetByIdAsync(id);
  }
}
