using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class YerbaMateProductConfiguration : IEntityTypeConfiguration<YerbaMate>
{
  public void Configure(EntityTypeBuilder<YerbaMate> builder)
  {
    builder.Property(p => p.Composition).IsRequired().HasMaxLength(150);
    builder.Property(p => p.Weight).IsRequired().HasMaxLength(20);
    builder.Property(p => p.HasAdditives).IsRequired();
    builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
    builder.HasOne(b => b.Country).WithMany().HasForeignKey(p => p.CountryId);
    builder.ToTable("YerbaMateProducts");
  }
}
