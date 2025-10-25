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
        
        builder.Property(p => p.FirstName).IsRequired();
        builder.Property(p => p.FirstName).HasMaxLength(128);

        builder.Property(p => p.MiddleName).HasMaxLength(128);
        
        builder.Property(p => p.LastName).HasMaxLength(128);
        
        builder.Property(p => p.NickName).HasMaxLength(256);
        
        builder.Property(p => p.Email).HasMaxLength(128);
        builder.Property(p => p.Password).HasMaxLength(256);
        
        // To store string in database with enum GenderType
        builder.Property(p => p.GenderType)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<GenderType>(v));
        builder.Property(p => p.GenderType).HasMaxLength(64);

        builder
            .HasOne(e => e.Address)
            .WithOne(e => e.User)
            .HasForeignKey<Address>(e => e.UserId);

    }
}