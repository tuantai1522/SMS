using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = SMS.Core.Features.Tasks.Task;

namespace SMS.Infrastructure.Configuration.Tasks;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        // Rename to snake case
        builder.ToTable("tasks");
        
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(256);
        
        builder.Property(p => p.Code).IsRequired();
        builder.Property(p => p.Code).HasMaxLength(256);
        
        // Must unique code in project
        builder.HasIndex(x => new { x.Code, x.ProjectId }).IsUnique();
        
        // One task belongs to one project
        builder.HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(p => p.ProjectId);
        
        // One task belongs to one task status
        builder.HasOne(t => t.TaskStatus)
            .WithMany()
            .HasForeignKey(p => p.StatusId);

        // One task belongs to one task priority
        builder.HasOne(t => t.TaskPriority)
            .WithMany()
            .HasForeignKey(p => p.PriorityId);

        // One task is assigned to one user
        builder.HasOne(t => t.AssignedTo)
            .WithMany()
            .HasForeignKey(p => p.AssignedToId);

        // One task is created by one user
        builder.HasOne(t => t.Creator)
            .WithMany()
            .HasForeignKey(p => p.CreatorId);
    }
}