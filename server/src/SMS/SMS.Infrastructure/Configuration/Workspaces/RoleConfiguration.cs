using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Workspaces;

namespace SMS.Infrastructure.Configuration.Workspaces;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // Rename to snake case
        builder.ToTable("roles");
        
        builder.Property(p => p.Name).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Name).HasMaxLength(256);

    }
}