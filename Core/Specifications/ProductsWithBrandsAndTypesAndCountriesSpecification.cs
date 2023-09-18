using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class ProductsWithBrandsAndTypesAndCountriesSpecification : BaseSpecfication<Product>
{
  public ProductsWithBrandsAndTypesAndCountriesSpecification(ProductSpecParams productParams)
  : base(x =>
      (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
      (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
      (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId) &&
      (!productParams.CountryId.HasValue || x.CountryId == productParams.CountryId)
        )
  {
    AddInclude(x => x.ProductType);
    AddInclude(x => x.ProductBrand);
    AddInclude(x => x.Country);
    // AddOrderByAscending(x => x.Name);
    ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),productParams.PageSize);

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

  public ProductsWithBrandsAndTypesAndCountriesSpecification(int id) : base(x => x.Id == id)
  {
    AddInclude(x => x.ProductType);
    AddInclude(x => x.ProductBrand);
    AddInclude(x => x.Country);
  }
}
