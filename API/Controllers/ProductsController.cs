using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using API.Helpers;
using AutoMapper;
using API.Dtos;
using API.Errors;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private readonly IGenericRepository<Product> _productRepository;
  private readonly IMapper _mapper;

  public ProductsController(
    IGenericRepository<Product> productRepository,
    IMapper mapper
    )
  {
    _productRepository = productRepository;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
  {
    var specification = new ProductsWithBrandsAndTypesSpecification();
    var products = await _productRepository.ListWithSpecificationAsync(specification);
    var productsDto = _mapper.Map<IReadOnlyList<ProductDto>>(products);
    return Ok(productsDto);
  }

  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
  public async Task<ActionResult<ProductDto>> GetProduct(int id)
  {
    var specification = new ProductsWithBrandsAndTypesSpecification(id);
    Product product = await _productRepository.GetEntityWithSpecificationAsync(specification);
    if (product == null)
      return NotFound(new ApiResponse(404));
    return _mapper.Map<ProductDto>(product);
  }
}
