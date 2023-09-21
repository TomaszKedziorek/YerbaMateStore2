using Core.Entities;

namespace Core.Specifications;
public class BombillaWithFiltersForCountSpecification : BaseSpecfication<Bombilla>
{
  public BombillaWithFiltersForCountSpecification(BombillaSpecParams productParams)
   : base(x =>
      (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
      (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )
  {

  }
}