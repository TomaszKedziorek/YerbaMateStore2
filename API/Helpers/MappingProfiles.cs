using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<Product, ProductDto>()
      .ForMember(d => d.ProductType, o => o.MapFrom(x => x.ProductType.Name))
      .ForMember(d => d.Images, o => o.MapFrom<ProductImagesUrlResolver>());

    CreateMap<YerbaMate, YerbaMateDto>()
      .ForMember(d => d.Brand, o => o.MapFrom(x => x.ProductBrand.Name))
      .ForMember(d => d.Country, o => o.MapFrom(x => x.Country.Name))
      .ForMember(d => d.CountryCode, o => o.MapFrom(x => x.Country.IsoAlfa2Code))
      .ForMember(d => d.ProductType, o => o.MapFrom(x => x.ProductType.Name))
      .ForMember(d => d.Images, o => o.MapFrom<ProductImagesUrlResolver>());

    CreateMap<Bombilla, BombillaDto>()
      .ForMember(d => d.ProductType, o => o.MapFrom(x => x.ProductType.Name))
      .ForMember(d => d.Images, o => o.MapFrom<ProductImagesUrlResolver>());

    CreateMap<Cup, CupDto>()
      .ForMember(d => d.ProductType, o => o.MapFrom(x => x.ProductType.Name))
      .ForMember(d => d.Images, o => o.MapFrom<ProductImagesUrlResolver>());

  }
}