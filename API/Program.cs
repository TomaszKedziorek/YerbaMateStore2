using System.Text.Json.Serialization;
using API.Errors;
using API.Helpers;
using API.Middleware;
using Core.Interfaces;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace API;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    string? connectionString = builder.Configuration.GetConnectionString("StoreApiConnectionString");
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

    builder.Services.AddAutoMapper(typeof(MappingProfiles));
    builder.Services.AddControllers();

    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
      options.InvalidModelStateResponseFactory = actionContext =>
      {
        string[]? errors = actionContext.ModelState
        .Where(e => e.Value != null && e.Value.Errors.Count > 0)
        .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToArray();
        ValidationErrorResponse errorResponse = new() { Errors = errors };
        return new BadRequestObjectResult(errorResponse);
      };
    });
    builder.Services.AddControllers().AddJsonOptions(options =>
     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
   );
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "YerbaMateStore2 API", Version = "v1" });
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseMiddleware<ExceptionMiddleware>();

    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "YerbaMateStore2 API");
      });
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
