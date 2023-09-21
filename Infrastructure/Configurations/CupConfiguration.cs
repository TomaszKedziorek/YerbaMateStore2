using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class CupConfiguration : IEntityTypeConfiguration<Cup>
{
  public void Configure(EntityTypeBuilder<Cup> builder)
  {
    builder.Property(p => p.Material).IsRequired().HasMaxLength(150);
    builder.Property(p => p.Volume).IsRequired().HasMaxLength(20);
    builder.ToTable("CupProducts");
  }
}
