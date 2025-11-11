namespace SMS.Core.Features.Tasks;

public interface ITaskPriorityRepository
{
    Task<IReadOnlyList<TaskPriority>> GetTaskPrioritiesAsync(CancellationToken cancellationToken);
}