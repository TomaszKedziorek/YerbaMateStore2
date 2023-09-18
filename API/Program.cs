using API.Helpers;
using API.Middleware;
using Core.Interfaces;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace API;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    string? connectionString = builder.Configuration.GetConnectionString("StoreApiConnectionString");
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    builder.Services.AddAutoMapper(typeof(MappingProfiles));
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseMiddleware<ExceptionMiddleware>();
    
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }
    app.UseStatusCodePagesWithReExecute("/errors/{0}");

    SeedDatabase(app);

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseAuthorization();


    app.MapControllers();

    app.Run();
  }

  static async void SeedDatabase(WebApplication app)
  {
    using (var scope = app.Services.CreateScope())
    {
      var services = scope.ServiceProvider;
      var loggerFactory = services.GetRequiredService<ILoggerFactory>();
      try
      {
        var dbContext = services.GetRequiredService<AppDbContext>();
        if (dbContext.Database.GetPendingMigrations().Any())
        {
          await dbContext.Database.MigrateAsync();
        }
        await AppDbContextSeed.SeedAsync(dbContext, loggerFactory);
      }
      catch (Exception e)
      {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(e, "An error occured during migrations");
      }
    }
  }
}
