using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Workspaces;

namespace SMS.Infrastructure.Configuration.Workspaces;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        // Rename to snake case
        builder.ToTable("role_permissions");
        
        // One role permission belongs to one role
        builder.HasOne<Role>()
            .WithMany(role => role.RolePermissions)
            .HasForeignKey(p => p.RoleId);
        
        // One role permission belongs to one permission
        builder.HasOne<Permission>()
            .WithMany()
            .HasForeignKey(p => p.PermissionId);

    }
}