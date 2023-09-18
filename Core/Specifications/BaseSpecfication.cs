using System.Linq.Expressions;

namespace Core.Specifications;
public class BaseSpecfication<T> : ISpecification<T>
{
  public BaseSpecfication() { }

  public BaseSpecfication(Expression<Func<T, bool>> criteria)
  {
    Criteria = criteria;
  }

  public Expression<Func<T, bool>> Criteria { get; }

  public List<Expression<Func<T, object>>> Includes { get; } = new();

  protected void AddInclude(Expression<Func<T, object>> includeExpression)
  {
    Includes.Add(includeExpression);
  }
}