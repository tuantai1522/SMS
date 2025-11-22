namespace SMS.Core.Features.Tasks;

public interface ITaskRepository
{
    Task<Task> AddTaskAsync(Task task, CancellationToken cancellationToken);
    
    IQueryable<Task> GetTasksOrderByTitleAsync(Guid workspaceId, Guid? projectId, IReadOnlyList<Guid>? statusIds, IReadOnlyList<Guid>? priorityIds,
        IReadOnlyList<Guid>? assignedToIds, string? keyWord, long? dueDate, bool isAscending, CancellationToken cancellationToken);
    
    IQueryable<Task> GetTasksOrderByProjectNameAsync(Guid workspaceId, Guid? projectId, IReadOnlyList<Guid>? statusIds, IReadOnlyList<Guid>? priorityIds,
        IReadOnlyList<Guid>? assignedToIds, string? keyWord, long? dueDate, bool isAscending, CancellationToken cancellationToken);
}