using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class ProductsWithBrandsAndTypesSpecification : BaseSpecfication<Product>
{
  public ProductsWithBrandsAndTypesSpecification()
  {
    AddInclude(x => x.ProductType);
    AddInclude(x => x.ProductBrand);
    AddInclude(x => x.Country);
  }

  public ProductsWithBrandsAndTypesSpecification(int id) : base(x => x.Id == id)
  {
    AddInclude(x => x.ProductType);
    AddInclude(x => x.ProductBrand);
    AddInclude(x => x.Country);
  }
}
