using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Workspaces;

namespace SMS.Infrastructure.Configuration.Workspaces;

public class ViewConfiguration : IEntityTypeConfiguration<View>
{
    public void Configure(EntityTypeBuilder<View> builder)
    {
        // Rename to snake case
        builder.ToTable("views");
        
        builder.Property(p => p.Name).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Name).HasMaxLength(256);

        builder.HasIndex(p => p.Vid).IsUnique();
        builder.Property(p => p.Vid).HasMaxLength(256);
        
        // One view has multiple view roles
        builder.HasMany(team => team.ViewRoles)
            .WithOne()
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