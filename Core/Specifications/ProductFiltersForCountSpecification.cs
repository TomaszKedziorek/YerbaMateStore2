using Core.Entities;

namespace Core.Specifications;
public class ProductFiltersForCountSpecification : BaseSpecfication<Product>
{
  public ProductFiltersForCountSpecification(ProductSpecParams productParams)
   : base(x =>
      (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
      (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )
  {

  }
}