using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Specifications;
public interface ISpecification<T>
{
  Expression<Func<T, bool>> Criteria { get; }
  List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; }
  Expression<Func<T, object>> OrderByAscending { get; }
  Expression<Func<T, object>> OrderByDescending { get; }
  int Take { get; }
  int Skip { get; }
  bool IsPagingEnabled { get; }
}