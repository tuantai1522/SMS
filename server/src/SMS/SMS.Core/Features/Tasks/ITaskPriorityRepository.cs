namespace SMS.Core.Features.Tasks;

public interface ITaskPriorityRepository
{
    Task<IReadOnlyList<TaskPriority>> GetTaskPrioritiesAsync(CancellationToken cancellationToken);
    
    Task<bool> VerifyExistedPriorityByIdAsync(Guid id, CancellationToken cancellationToken);
}