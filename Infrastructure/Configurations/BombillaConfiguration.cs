using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class BombillaProductConfiguration : IEntityTypeConfiguration<Bombilla>
{
  public void Configure(EntityTypeBuilder<Bombilla> builder)
  {
    builder.Property(p => p.Material).IsRequired().HasMaxLength(150);
    builder.Property(p => p.Length).IsRequired().HasMaxLength(20);
    builder.Property(p => p.IsUnscrewed).IsRequired();
    builder.ToTable("BombillaProducts");
  }
}
