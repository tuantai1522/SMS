using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Users;

namespace SMS.Infrastructure.Configuration.Users;

public class UserSignInConfiguration : IEntityTypeConfiguration<UserSignIn>
{
    public void Configure(EntityTypeBuilder<UserSignIn> builder)
    {
        // Rename to snake case
        builder.ToTable("user_signins");
        
        builder.Property(p => p.Id).ValueGeneratedNever();
        
        // To store string in database with enum ProviderType
        builder.Property(p => p.ProviderType)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<ProviderType>(v));
        builder.Property(p => p.ProviderType).HasMaxLength(64);
        
        builder.Property(p => p.ProviderKey).IsRequired();
        builder.Property(p => p.ProviderKey).HasMaxLength(1024);
        
        builder.Property(p => p.ProviderEmail).HasMaxLength(512);

    }
}