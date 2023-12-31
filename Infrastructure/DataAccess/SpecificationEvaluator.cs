using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;
public class SpecificationEvaluator<T> where T : BaseEntity
{
  public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
  {
    var query = inputQuery;
    if (specification.Criteria != null)
      query = query.Where(specification.Criteria);

    if (specification.OrderByAscending != null)
      query = query.OrderBy(specification.OrderByAscending);

    if (specification.OrderByDescending != null)
      query = query.OrderByDescending(specification.OrderByDescending);

    if (specification.IsPagingEnabled)
      query = query.Skip(specification.Skip).Take(specification.Take);

    query = specification.Includes.Aggregate(query, (current, include) => include(current));
    return query;
  }
}
