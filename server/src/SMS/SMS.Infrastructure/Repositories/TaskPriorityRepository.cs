using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Tasks;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class TaskPriorityRepository(ApplicationDbContext context) : ITaskPriorityRepository
{
    public async Task<IReadOnlyList<TaskPriority>> GetTaskPrioritiesAsync(CancellationToken cancellationToken)
    {
        return await context.Set<TaskPriority>()
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> VerifyExistedPriorityByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<TaskPriority>()
            .AnyAsync(x => x.Id == id, cancellationToken);
    }
}