using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Countries;
using SMS.Core.Features.Users;

namespace SMS.Infrastructure.Configuration.Users;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        // Rename to snake case
        builder.ToTable("addresses");
        
        builder.Property(p => p.Id).ValueGeneratedNever();
        
        builder.Property(p => p.Street).HasMaxLength(512);

        // One address belongs to one city
        builder.HasOne(a => a.City)
            .WithMany()
            .HasForeignKey(u => u.CityId);
    }
}