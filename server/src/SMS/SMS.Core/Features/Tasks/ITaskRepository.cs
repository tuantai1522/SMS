namespace SMS.Core.Features.Tasks;

public interface ITaskRepository
{
    Task<Task> AddTaskAsync(Task task, CancellationToken cancellationToken);
}