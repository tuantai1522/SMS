using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.RefreshTokens;

namespace SMS.Infrastructure.Configuration.RefreshTokens;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        // Rename to snake case
        builder.ToTable("refresh_tokens");
        
        builder.Property(c => c.Id).ValueGeneratedNever();
        
        builder.Property(p => p.Token).IsRequired();
        builder.Property(p => p.Token).HasMaxLength(1024);
    }
}
