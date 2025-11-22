using SMS.Core.Common;
using Task = SMS.Core.Features.Tasks.Task;

namespace SMS.Core.Features.Projects;

public sealed class Project : AggregateRoot, IDateTracking, ISoftDelete
{
    public string Name { get; private set; } = null!;
    public string Code { get; private set; } = null!;
    public string? Emoji { get; private set; }
    
    public string? Description { get; private set; }

    public int TotalTasks { get; private set; }
    
    public Guid WorkspaceId { get; init; }
    public Guid CreatorId { get; init; }
    
    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }
    public long? DeletedAt { get; private set; }
    
    /// <summary>
    /// List tasks of this project.
    /// </summary>
    private readonly List<Task> _tasks = [];
    
    public IReadOnlyList<Task> Tasks => _tasks.ToList();
    
    private Project() { }

    public static Project CreateProject(string name, string code, string? emoji, string? description, Guid workspaceId, Guid createdBy)
    {
        return new Project
        {
            Name = name,
            Code = code,
            Emoji = emoji,
            Description = description,
            CreatorId = createdBy,
            WorkspaceId = workspaceId,
        };
    }
    
    public void Delete()
    {
        DeletedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public void UpdateTotalTasks()
    {
        TotalTasks += 1;
    }
    
    public void Update(string name, string code, string? emoji, string? description)
    {
        Name = name;
        Code = code;
        Emoji = emoji;
        Description = description;
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}