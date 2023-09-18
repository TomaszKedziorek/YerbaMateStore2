using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DataAccess;
public class AppDbContextSeed
{
  public static async Task SeedAsync(AppDbContext dbContext, ILoggerFactory loggerFactory)
  {
    try
    {
      if (!dbContext.Countries.Any())
      {
        string countriesData = File.ReadAllText("../Infrastructure/DataAccess/SeedData/countries.json");
        var countries = JsonSerializer.Deserialize<List<Country>>(countriesData);
        await dbContext.Countries.AddRangeAsync(countries);
        await dbContext.SaveChangesAsync();
      }
      if (!dbContext.ProductBrands.Any())
      {
        string brandsData = File.ReadAllText("../Infrastructure/DataAccess/SeedData/brands.json");
        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
        await dbContext.ProductBrands.AddRangeAsync(brands);
        await dbContext.SaveChangesAsync();
      }
      if (!dbContext.ProductTypes.Any())
      {
        string typesData = File.ReadAllText("../Infrastructure/DataAccess/SeedData/types.json");
        var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
        await dbContext.ProductTypes.AddRangeAsync(types);
        await dbContext.SaveChangesAsync();
      }
      if (!dbContext.Products.Any())
      {
        string productsData = File.ReadAllText("../Infrastructure/DataAccess/SeedData/products.json");
        var products = JsonSerializer.Deserialize<List<Product>>(productsData);
        await dbContext.Products.AddRangeAsync(products);
        await dbContext.SaveChangesAsync();
      }
    }
    catch (Exception e)
    {
      var loggger = loggerFactory.CreateLogger<AppDbContext>();
      loggger.LogError(e.Message);
    }
  }
}
