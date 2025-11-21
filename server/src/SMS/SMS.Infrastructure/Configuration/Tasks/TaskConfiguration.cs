using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Projects;
using SMS.Core.Features.Users;
using Task = SMS.Core.Features.Tasks.Task;
using TaskStatus = SMS.Core.Features.Tasks.TaskStatus;
using TaskPriority = SMS.Core.Features.Tasks.TaskPriority;

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
        builder.HasOne<Project>()
            .WithMany(p => p.Tasks)
            .HasForeignKey(p => p.ProjectId);
        
        // One task belongs to one task status
        builder.HasOne<TaskStatus>()
            .WithMany()
            .HasForeignKey(p => p.StatusId);

        // One task belongs to one task priority
        builder.HasOne<TaskPriority>()
            .WithMany()
            .HasForeignKey(p => p.PriorityId);

        // One task is assigned to one user
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.AssignedTo);

        // One task is created by one user
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.CreatorId);
    }
}