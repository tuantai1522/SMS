using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Workspaces;

namespace SMS.Infrastructure.Configuration.Workspaces;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        // Rename to snake case
        builder.ToTable("permissions");
        
        builder.Property(p => p.Name).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Name).HasMaxLength(256);

    }
}