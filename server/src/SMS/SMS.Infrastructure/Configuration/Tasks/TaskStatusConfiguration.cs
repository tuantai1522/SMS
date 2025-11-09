using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskStatus = SMS.Core.Features.Tasks.TaskStatus;

namespace SMS.Infrastructure.Configuration.Tasks;

public class TaskStatusConfiguration : IEntityTypeConfiguration<TaskStatus>
{
    public void Configure(EntityTypeBuilder<TaskStatus> builder)
    {
        // Rename to snake case
        builder.ToTable("task_statuses");
        
        builder.Property(p => p.Name).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Name).HasMaxLength(256);

    }
}