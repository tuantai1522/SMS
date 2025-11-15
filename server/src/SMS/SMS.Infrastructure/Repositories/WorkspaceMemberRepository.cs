using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;

namespace SMS.Infrastructure.Repositories;

public sealed class WorkspaceMemberRepository(IApplicationDbContext context) : IWorkspaceMemberRepository
{
    public async Task<WorkspaceMember> AddWorkspaceMemberAsync(WorkspaceMember workspaceMember, CancellationToken cancellationToken)
    {
        var result = await context.Set<WorkspaceMember>().AddAsync(workspaceMember, cancellationToken);
        
        return result.Entity;
    }
}