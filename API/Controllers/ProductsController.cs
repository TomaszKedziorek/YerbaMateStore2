using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using API.Helpers;
using AutoMapper;
using API.Dtos;

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
  public async Task<ActionResult<ProductDto>> GetProduct(int id)
  {
    var specification = new ProductsWithBrandsAndTypesSpecification(id);
    Product product = await _productRepository.GetEntityWithSpecificationAsync(specification);
    return _mapper.Map<ProductDto>(product);
  }
}
