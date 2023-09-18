using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

public class ProductRepository : IProductRepository
{
  private readonly AppDbContext _dbContext;

  public ProductRepository(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<Product> GetProductByIdAync(int id)
  {
    return await _dbContext.Products.FindAsync(id);
  }

  public async Task<IReadOnlyList<Product>> GetProductsAync()
  {
    return await _dbContext.Products.ToListAsync();
  }
}
