using System.Text.Json;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DataAccess;
public class AppDbContextSeed
{
  public static async Task SeedAsync(AppDbContext dbContext, ILoggerFactory loggerFactory)
  {
    try
    {
      await SeedTableAsync<Country>(dbContext, "../Infrastructure/DataAccess/SeedData/countries.json");
      await SeedTableAsync<ProductBrand>(dbContext, "../Infrastructure/DataAccess/SeedData/brands.json");
      await SeedTableAsync<ProductType>(dbContext, "../Infrastructure/DataAccess/SeedData/types.json");
      await SeedTableAsync<YerbaMate>(dbContext, "../Infrastructure/DataAccess/SeedData/yerbaMateProducts.json");
      await SeedTableAsync<Bombilla>(dbContext, "../Infrastructure/DataAccess/SeedData/bombillaProducts.json");
      await SeedTableAsync<Cup>(dbContext, "../Infrastructure/DataAccess/SeedData/cupProducts.json");
      }
    catch (Exception e)
    {
      var loggger = loggerFactory.CreateLogger<AppDbContext>();
      loggger.LogError(e.Message);
    }
  }

  private static async Task SeedTableAsync<T>(AppDbContext dbContext, string jsonDataFile) where T : BaseEntity
  {
    if (!dbContext.Set<T>().Any())
    {
      string productsData = File.ReadAllText(jsonDataFile);
      var products = JsonSerializer.Deserialize<List<T>>(productsData);
      await dbContext.Set<T>().AddRangeAsync(products);
      await dbContext.SaveChangesAsync();
    }
  }
}
