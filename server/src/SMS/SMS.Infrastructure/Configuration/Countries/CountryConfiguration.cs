using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Countries;

namespace SMS.Infrastructure.Configuration.Countries;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        // Rename to snake case
        builder.ToTable("countries");
        
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(64);

        // One country has multiple cities
        builder.HasMany(country => country.Cities)
            .WithOne(city => city.Country)
            .HasForeignKey(p => p.CountryId);
    }
}