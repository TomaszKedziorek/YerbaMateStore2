using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.Property(p => p.Id).IsRequired();
    builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
    builder.Property(p => p.Description).IsRequired().HasMaxLength(300);
    builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
    builder.Property(p => p.Quantity).IsRequired();
    builder.HasOne(b => b.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
    builder.HasMany(p=>p.Images).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
  }
}
