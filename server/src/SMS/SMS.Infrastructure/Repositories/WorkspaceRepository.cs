using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;

namespace SMS.Infrastructure.Repositories;

public sealed class WorkspaceRepository(IApplicationDbContext context) : IWorkspaceRepository
{
    public async Task<Workspace> AddWorkspaceAsync(Workspace workspace, CancellationToken cancellationToken)
    {
        var result = await context.Set<Workspace>().AddAsync(workspace, cancellationToken);
        
        return result.Entity;
    }

    public async Task<Workspace?> FindWorkspaceByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Workspace>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}