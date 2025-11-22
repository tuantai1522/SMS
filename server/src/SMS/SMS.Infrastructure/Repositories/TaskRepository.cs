using SMS.Core.Features.Tasks;
using SMS.UseCases.Abstractions.Data;
using Task = SMS.Core.Features.Tasks.Task;

namespace SMS.Infrastructure.Repositories;

public sealed class TaskRepository(IApplicationDbContext context) : ITaskRepository
{
    public async Task<Task> AddTaskAsync(Task task, CancellationToken cancellationToken)
    {
        var result = await context.Set<Task>().AddAsync(task, cancellationToken);
        
        return result.Entity;
    }
}