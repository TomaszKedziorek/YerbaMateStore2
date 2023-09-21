using Core.Entities;

namespace Core.Specifications;
public class CupWithFiltersForCountSpecification : BaseSpecfication<Cup>
{
  public CupWithFiltersForCountSpecification(CupSpecParams productParams)
   : base(x =>
      (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
      (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )
  {

  }
}