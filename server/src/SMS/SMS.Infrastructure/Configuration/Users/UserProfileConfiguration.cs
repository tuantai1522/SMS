using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Users;

namespace SMS.Infrastructure.Configuration.Users;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        // Rename to snake case
        builder.ToTable("user_profiles");

        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.Property(p => p.GivenName).HasMaxLength(128);
        
        builder.Property(p => p.AvatarUrl).HasMaxLength(1024);
    }
}