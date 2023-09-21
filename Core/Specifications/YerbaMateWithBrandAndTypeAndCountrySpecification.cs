using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Specifications;

public class YerbaMateWithBrandAndTypeAndCountrySpecification : BaseSpecfication<YerbaMate>
{
  public YerbaMateWithBrandAndTypeAndCountrySpecification(YerbaMateSpecParams productParams)
  : base(x =>
      (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
      (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
      (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId) &&
      (!productParams.CountryId.HasValue || x.CountryId == productParams.CountryId)
        )
  {
    AddInclude(q => q.Include(x => x.Country));
    AddInclude(q => q.Include(x => x.ProductBrand));
    AddInclude(q => q.Include(x => x.ProductType));
    ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

    if (!string.IsNullOrEmpty(productParams.Sort))
    {
      switch (productParams.Sort)
      {
        case "priceAsc":
          AddOrderByAscending(x => x.Price);
          break;
        case "priceDesc":
          AddOrderByDescending(x => x.Price);
          break;
        case "nameAsc":
          AddOrderByAscending(x => x.Name);
          break;
        case "nameDesc":
          AddOrderByDescending(x => x.Name);
          break;
        default:
          AddOrderByAscending(x => x.Name);
          break;
      }
    }
  }
  public YerbaMateWithBrandAndTypeAndCountrySpecification(int id) : base(x => x.Id == id)
  {
    AddInclude(q => q.Include(x => x.Country));
    AddInclude(q => q.Include(x => x.ProductBrand));
    AddInclude(q => q.Include(x => x.ProductType));
  }
}
