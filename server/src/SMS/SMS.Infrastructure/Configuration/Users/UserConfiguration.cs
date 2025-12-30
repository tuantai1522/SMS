using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Users;

namespace SMS.Infrastructure.Configuration.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Rename to snake case
        builder.ToTable("users");
        
        builder.Property(p => p.Email).HasMaxLength(128);
        builder.HasIndex(p => p.Email).IsUnique();
        
        builder.Property(p => p.Password).HasMaxLength(256);
        builder.Property(p => p.VerificationToken).HasMaxLength(256);
        
        // To store string in database with enum UserStatus
        builder.Property(p => p.Status)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<UserStatus>(v));
        builder.Property(p => p.Status).HasMaxLength(64);

        builder
            .HasOne(u => u.UserProfile)
            .WithOne(up => up.User)
            .OnDelete(DeleteBehavior.Restrict);
;
        
        // One user has multiple RefreshTokens
        builder.HasMany(x => x.RefreshTokens)
            .WithOne()
            .HasForeignKey(u => u.UserId);
        
        // One user has multiple UserSignIns
        builder.HasMany(x => x.UserSignIns)
            .WithOne()
            .HasForeignKey(u => u.UserId);

    }
}