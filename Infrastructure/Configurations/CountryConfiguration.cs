using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
  public void Configure(EntityTypeBuilder<Country> builder)
  {
    builder.Property(p => p.Id).IsRequired();
    builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
    builder.Property(p => p.IsoAlfa2Code).IsRequired().HasMaxLength(2);
  }
}
