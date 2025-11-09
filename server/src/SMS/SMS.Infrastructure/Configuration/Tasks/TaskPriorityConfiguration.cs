using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Tasks;

namespace SMS.Infrastructure.Configuration.Tasks;

public class TaskPriorityConfiguration : IEntityTypeConfiguration<TaskPriority>
{
    public void Configure(EntityTypeBuilder<TaskPriority> builder)
    {
        // Rename to snake case
        builder.ToTable("task_priorities");
        
        builder.Property(p => p.Name).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Name).HasMaxLength(256);

    }
}