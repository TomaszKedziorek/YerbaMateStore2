using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepository
{
  Task<Product> GetProductByIdAync(int id);
  Task<IReadOnlyList<Product>> GetProductsAync();
}
