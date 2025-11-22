using SMS.Core.Common;
using SMS.Core.Features.Projects;
using SMS.Core.Features.Users;

namespace SMS.Core.Features.Tasks;

public sealed class Task : AggregateRoot, IDateTracking, ISoftDelete
{
    public string Name { get; private set; } = null!;
    public string Code { get; private set; } = null!;
    
    public string? Description { get; private set; }
    
    public Guid ProjectId { get; private set; }
    public Project Project { get; private set; } = null!;
    
    public Guid StatusId { get; private set; }
    public TaskStatus TaskStatus { get; private set; } = null!;
    
    public Guid PriorityId { get; private set; }
    public TaskPriority TaskPriority { get; private set; } = null!;
    
    public Guid? AssignedToId { get; private set; }
    public User? AssignedTo { get; private set; }
    
    public Guid CreatorId { get; private set; }
    public User Creator { get; private set; } = null!;
    
    
    public long? StartDate { get; private set; }
    public long? DueDate { get; private set; }

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }
    public long? DeletedAt { get; private set; }
    
    private Task() { }

    public static Task CreateTask(string name, string code, string? description, Guid projectId, Guid statusId,
        Guid priorityId, Guid? assignedToId, Guid createdBy, long? startDate, long? dueDate)
    {
        return new Task
        {
            Name = name,
            Code = code,
            Description = description,
            ProjectId = projectId,
            StatusId = statusId,
            PriorityId = priorityId,
            AssignedToId = assignedToId,
            CreatorId = createdBy,
            StartDate = startDate,
            DueDate = dueDate,
        };
    }

    public void Delete()
    {
        DeletedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}