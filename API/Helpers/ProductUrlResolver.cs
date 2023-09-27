using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API.Helpers;
public class ProductImagesUrlResolver : IValueResolver<Product, ProductDto, IEnumerable<ImageDto>>
{
  private readonly IConfiguration _configuration;

  public ProductImagesUrlResolver(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public IEnumerable<ImageDto> Resolve(Product source, ProductDto destination, IEnumerable<ImageDto> destMember, ResolutionContext context)
  {
    List<ImageDto> images = new();
    if (!source.Images.IsNullOrEmpty())
    {
      foreach (var image in source.Images)
      {
        images.Add(new ImageDto()
        {
          Id = image.Id,
          PictureUrl = _configuration["ApiUrl"] + image.PictureUrl
        });
      }
    }
    return images;
  }
}
