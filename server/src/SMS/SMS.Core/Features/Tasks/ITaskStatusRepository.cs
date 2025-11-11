namespace SMS.Core.Features.Tasks;

public interface ITaskStatusRepository
{
    Task<IReadOnlyList<TaskStatus>> GetTaskStatusesAsync(CancellationToken cancellationToken);
}