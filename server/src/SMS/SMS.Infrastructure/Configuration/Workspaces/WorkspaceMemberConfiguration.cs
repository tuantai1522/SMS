using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Users;
using SMS.Core.Features.Workspaces;

namespace SMS.Infrastructure.Configuration.Workspaces;

public class WorkspaceMemberConfiguration : IEntityTypeConfiguration<WorkspaceMember>
{
    public void Configure(EntityTypeBuilder<WorkspaceMember> builder)
    {
        // Rename to snake case
        builder.ToTable("workspace_members");
        
        // One workspace member belongs to one workspace
        builder.HasOne<Workspace>()
            .WithMany(w => w.WorkspaceMembers)
            .HasForeignKey(p => p.WorkspaceId);

        // One workspace member belongs to one user
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);

        // One workspace member belongs to one role
        builder.HasOne<Role>()
            .WithMany()
            .HasForeignKey(p => p.RoleId);

    }
}