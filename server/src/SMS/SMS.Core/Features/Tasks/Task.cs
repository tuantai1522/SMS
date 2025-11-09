using SMS.Core.Common;

namespace SMS.Core.Features.Tasks;

public sealed class Task : AggregateRoot, IDateTracking, ISoftDelete
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
        
    public string Name { get; private set; } = null!;
    public string Code { get; private set; } = null!;
    
    public string? Description { get; private set; }
    
    public Guid ProjectId { get; init; }
    
    public Guid StatusId { get; private set; }
    
    public Guid PriorityId { get; private set; }
    
    public Guid? AssignedTo { get; private set; }
    
    public Guid CreatorId { get; private set; }
    
    
    public long? StartDate { get; private set; }
    public long? DueDate { get; private set; }

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }
    public long? DeletedAt { get; private set; }
    
    private Task() { }

    public static Task CreateTask(string name, string code, string? description, Guid projectId, Guid statusId,
        Guid priorityId, Guid? assignedTo, Guid createdBy, long? startDate, long? dueDate)
    {
        return new Task
        {
            Name = name,
            Code = code,
            Description = description,
            ProjectId = projectId,
            StatusId = statusId,
            PriorityId = priorityId,
            AssignedTo = assignedTo,
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