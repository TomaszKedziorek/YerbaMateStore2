using System.Runtime.CompilerServices;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
  private readonly AppDbContext _dbContext;

  public GenericRepository(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<T> GetByIdAsync(int id)
  {
    return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<IReadOnlyList<T>> GetAllAsync()
  {
    return await _dbContext.Set<T>().ToListAsync();
  }

  public async Task<T> GetEntityWithSpecificationAsync(ISpecification<T> specification)
  {
    return await ApplySpecification(specification).FirstOrDefaultAsync();
  }

  public async Task<IReadOnlyList<T>> ListWithSpecificationAsync(ISpecification<T> specification)
  {
    return await ApplySpecification(specification).ToListAsync();
  }

  private IQueryable<T> ApplySpecification(ISpecification<T> specification)
  {
    return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), specification);
  }
}
