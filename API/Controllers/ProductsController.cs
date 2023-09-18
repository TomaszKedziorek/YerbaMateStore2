using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;

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
    var specification = new ProductsWithBrandsAndTypesSpecification();
    var products = await _productRepository.ListWithSpecificationAsync(specification);
    return Ok(products);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Product>> GetProduct(int id)
  {
    var specification = new ProductsWithBrandsAndTypesSpecification(id);
    return await _productRepository.GetEntityWithSpecificationAsync(specification);
  }
}
