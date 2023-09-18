using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.DataAccess;

public class AppDbContext : DbContext
{
  public DbSet<Product> Products { get; set; }
  public DbSet<ProductType> ProductTypes { get; set; }
  public DbSet<ProductBrand> ProductBrands { get; set; }

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
  }
}