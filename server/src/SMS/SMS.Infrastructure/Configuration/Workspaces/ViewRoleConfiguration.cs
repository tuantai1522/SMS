using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Workspaces;

namespace SMS.Infrastructure.Configuration.Workspaces;

public class ViewRoleConfiguration : IEntityTypeConfiguration<ViewRole>
{
    public void Configure(EntityTypeBuilder<ViewRole> builder)
    {
        // Rename to snake case
        builder.ToTable("view_roles");
        
        // One view role belongs to one role
        builder.HasOne<Role>()
            .WithMany(role => role.ViewRoles)
            .HasForeignKey(p => p.RoleId);
        
        // One view role belongs to one view
        builder.HasOne<View>()
            .WithMany(view => view.ViewRoles)
            .HasForeignKey(p => p.ViewId);
        
        // To config view permission
        builder.OwnsOne(
            o => o.ViewPermission,
            sa =>
            {
                sa.Property(p => p.AllowRead).HasColumnName(nameof(ViewPermission.AllowRead));
                sa.Property(p => p.AllowUpdate).HasColumnName(nameof(ViewPermission.AllowUpdate));
                sa.Property(p => p.AllowDelete).HasColumnName(nameof(ViewPermission.AllowDelete));
                sa.Property(p => p.AllowCreate).HasColumnName(nameof(ViewPermission.AllowCreate));
            });

    }
}