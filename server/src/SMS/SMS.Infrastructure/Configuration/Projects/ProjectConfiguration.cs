using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Projects;
using SMS.Core.Features.Users;
using SMS.Core.Features.Workspaces;

namespace SMS.Infrastructure.Configuration.Projects;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        // Rename to snake case
        builder.ToTable("projects");
        
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(256);
        
        builder.Property(p => p.Code).IsRequired();
        builder.Property(p => p.Code).HasMaxLength(256);
        
        builder.Property(p => p.Emoji).HasMaxLength(256);
        
        // One project belongs to one workspace
        builder.HasOne<Workspace>()
            .WithMany()
            .HasForeignKey(p => p.WorkspaceId);
        
        // One project is created by one user
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.CreatorId);
    }
}