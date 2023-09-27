using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Specifications;
public class BaseSpecfication<T> : ISpecification<T>
{
  public BaseSpecfication() { }

  public BaseSpecfication(Expression<Func<T, bool>> criteria)
  {
    Criteria = criteria;
  }

  public Expression<Func<T, bool>> Criteria { get; }
  public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; } = new();
  public Expression<Func<T, object>> OrderByAscending { get; private set; }
  public Expression<Func<T, object>> OrderByDescending { get; private set; }
  public int Take { get; private set; }
  public int Skip { get; private set; }
  public bool IsPagingEnabled { get; private set; }

  protected void AddInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> includeExpression)
  {
    Includes.Add(includeExpression);
  }
  protected void AddOrderByAscending(Expression<Func<T, object>> orderByAscExpression)
  {
    OrderByAscending = orderByAscExpression;
  }
  protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
  {
    OrderByDescending = orderByDescExpression;
  }
  protected void ApplyPaging(int skip, int take)
  {
    Skip = skip;
    Take = take;
    IsPagingEnabled = true;
  }


}