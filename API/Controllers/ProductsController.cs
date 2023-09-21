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
  private readonly IGenericRepository<YerbaMate> _yerbaMateRepository;
  private readonly IGenericRepository<Bombilla> _bombillaRepository;
  private readonly IGenericRepository<Cup> _cupRepository;
  private readonly IGenericRepository<Product> _productRepository;
  private readonly IMapper _mapper;

  public ProductsController(
    IGenericRepository<YerbaMate> yerbaMateRepository,
    IGenericRepository<Bombilla> bombillaRepository,
    IGenericRepository<Cup> cupRepository,
    IGenericRepository<Product> productRepository,
    IMapper mapper
    )
  {
    _yerbaMateRepository = yerbaMateRepository;
    _bombillaRepository = bombillaRepository;
    _cupRepository = cupRepository;
    _productRepository = productRepository;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<ActionResult<Pagination<ProductDto>>> GetProducts(
    [FromQuery] ProductSpecParams productParams)
  {
    var specification = new ProductWithTypeSpecification(productParams);
    var countSpecification = new ProductFiltersForCountSpecification(productParams);

    IReadOnlyList<Product>? products = await _productRepository.ListWithSpecificationAsync(specification);
    int totalItems = await _productRepository.CountWithSpecificationAsync(countSpecification);

    IReadOnlyList<ProductDto>? data = _mapper.Map<IReadOnlyList<ProductDto>>(products);
    return Ok(new Pagination<ProductDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ProductDto>> GetProduct(int id)
  {
    var specification = new ProductWithTypeSpecification(id);
    Product product = await _productRepository.GetEntityWithSpecificationAsync(specification);
    if (product == null)
      return NotFound(new ApiResponse(404));
    return _mapper.Map<ProductDto>(product);
  }

  [HttpGet("yerbamate")]
  public async Task<ActionResult<Pagination<YerbaMateDto>>> GetYerbaMateProducts(
    [FromQuery] YerbaMateSpecParams productParams)
  {
    var specification = new YerbaMateWithBrandAndTypeAndCountrySpecification(productParams);
    var countSpecification = new YerbaMateWithFiltersForCountSpecification(productParams);

    IReadOnlyList<YerbaMate>? products = await _yerbaMateRepository.ListWithSpecificationAsync(specification);
    int totalItems = await _yerbaMateRepository.CountWithSpecificationAsync(countSpecification);

    IReadOnlyList<YerbaMateDto>? data = _mapper.Map<IReadOnlyList<YerbaMateDto>>(products);
    return Ok(new Pagination<YerbaMateDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
  }

  [HttpGet("yerbamate/{id}")]
  public async Task<ActionResult<YerbaMateDto>> GetYerbaMateProduct(int id)
  {
    var specification = new YerbaMateWithBrandAndTypeAndCountrySpecification(id);
    YerbaMate product = await _yerbaMateRepository.GetEntityWithSpecificationAsync(specification);
    if (product == null)
      return NotFound(new ApiResponse(404));
    return _mapper.Map<YerbaMateDto>(product);
  }

  [HttpGet("cup")]
  public async Task<ActionResult<Pagination<CupDto>>> GetCupProducts(
    [FromQuery] CupSpecParams productParams)
  {
    var specification = new CupSpecification(productParams);
    var countSpecification = new CupWithFiltersForCountSpecification(productParams);

    IReadOnlyList<Cup>? products = await _cupRepository.ListWithSpecificationAsync(specification);
    int totalItems = await _cupRepository.CountWithSpecificationAsync(countSpecification);

    IReadOnlyList<CupDto>? data = _mapper.Map<IReadOnlyList<CupDto>>(products);
    return Ok(new Pagination<CupDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
  }

  [HttpGet("cup/{id}")]
  public async Task<ActionResult<CupDto>> GetCupProduct(int id)
  {
    var specification = new CupSpecification(id);
    Cup product = await _cupRepository.GetEntityWithSpecificationAsync(specification);
    if (product == null)
      return NotFound(new ApiResponse(404));
    return _mapper.Map<CupDto>(product);
  }

  [HttpGet("bombilla")]
  public async Task<ActionResult<Pagination<BombillaDto>>> GetBombillaProducts(
    [FromQuery] BombillaSpecParams productParams)
  {
    var specification = new BombillaSpecification(productParams);
    var countSpecification = new BombillaWithFiltersForCountSpecification(productParams);

    IReadOnlyList<Bombilla>? products = await _bombillaRepository.ListWithSpecificationAsync(specification);
    int totalItems = await _bombillaRepository.CountWithSpecificationAsync(countSpecification);

    IReadOnlyList<BombillaDto>? data = _mapper.Map<IReadOnlyList<BombillaDto>>(products);
    return Ok(new Pagination<BombillaDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
  }

  [HttpGet("bombilla/{id}")]
  public async Task<ActionResult<BombillaDto>> GetBombillaProduct(int id)
  {
    var specification = new BombillaSpecification(id);
    Bombilla product = await _bombillaRepository.GetEntityWithSpecificationAsync(specification);
    if (product == null)
      return NotFound(new ApiResponse(404));
    return _mapper.Map<BombillaDto>(product);
  }
}
