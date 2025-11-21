using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Tasks;
using SMS.Infrastructure.Database;
using TaskStatus = SMS.Core.Features.Tasks.TaskStatus;

namespace SMS.Infrastructure.Repositories;

public sealed class TaskStatusRepository(ApplicationDbContext context) : ITaskStatusRepository
{
    public async Task<IReadOnlyList<TaskStatus>> GetTaskStatusesAsync(CancellationToken cancellationToken)
    {
        return await context.Set<TaskStatus>()
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> VerifyExistedStatusByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<TaskStatus>()
            .AnyAsync(x => x.Id == id, cancellationToken);
    }
}