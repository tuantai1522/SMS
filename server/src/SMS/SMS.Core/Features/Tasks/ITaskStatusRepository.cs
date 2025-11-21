namespace SMS.Core.Features.Tasks;

public interface ITaskStatusRepository
{
    Task<IReadOnlyList<TaskStatus>> GetTaskStatusesAsync(CancellationToken cancellationToken);
    
    Task<bool> VerifyExistedStatusByIdAsync(Guid id, CancellationToken cancellationToken);
}