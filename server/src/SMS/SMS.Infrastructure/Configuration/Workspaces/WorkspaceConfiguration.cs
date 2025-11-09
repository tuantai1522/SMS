using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Users;
using SMS.Core.Features.Workspaces;

namespace SMS.Infrastructure.Configuration.Workspaces;

public class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        // Rename to snake case
        builder.ToTable("workspaces");
        
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(2048);
        builder.Property(p => p.InvitationCode).HasMaxLength(2048);
        builder.HasIndex(p => p.InvitationCode).IsUnique();
        
        // One workspace is created by one user
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.OwnerId);
        
        // One workspace has multiple workspace members
        builder
            .HasMany(ws => ws.WorkspaceMembers)
            .WithOne()
            .HasForeignKey(p => p.WorkspaceId);
    }
}