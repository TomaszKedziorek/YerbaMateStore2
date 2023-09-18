using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<Product, ProductDto>()
      .ForMember(d => d.ProductBrand, o => o.MapFrom(x => x.ProductBrand.Name))
      .ForMember(d => d.ProductType, o => o.MapFrom(x => x.ProductType.Name))
      .ForMember(d => d.Country, o => o.MapFrom(x => x.Country.Name))
      .ForMember(d => d.CountryCode, o => o.MapFrom(x => x.Country.IsoAlfa2Code))
      .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductUrlResolver>());
  }
}