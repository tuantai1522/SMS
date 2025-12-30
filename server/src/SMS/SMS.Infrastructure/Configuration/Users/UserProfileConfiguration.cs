using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Countries;
using SMS.Core.Features.Users;

namespace SMS.Infrastructure.Configuration.Users;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        // Rename to snake case
        builder.ToTable("user_profiles");

        builder.Property(p => p.GivenName).HasMaxLength(128);
        builder.HasIndex(p => p.GivenName).IsUnique();
        
        // One user belongs to one country
        builder.HasOne<Country>()
            .WithMany()
            .HasForeignKey(p => p.CountryId);

        // To store string in database with enum GenderType
        builder.Property(p => p.GenderType)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<GenderType>(v));
        builder.Property(p => p.GenderType).HasMaxLength(64);

        builder.Property(p => p.AvatarUrl).HasMaxLength(1024);
    }
}