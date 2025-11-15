using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;

namespace SMS.Infrastructure.Repositories;

public sealed class WorkspaceMemberRepository(IApplicationDbContext context) : IWorkspaceMemberRepository
{
    public async Task<WorkspaceMember?> GetWorkspaceMemberByWorkspaceIdAndUserIdAsync(Guid workspaceId, Guid userId, CancellationToken cancellationToken)
    {
        return await context.Set<WorkspaceMember>()
            .FirstOrDefaultAsync(workspaceMember => workspaceMember.WorkspaceId == workspaceId && 
                                                    workspaceMember.UserId == userId && 
                                                    !workspaceMember.DeletedAt.HasValue, cancellationToken);
    }

    public async Task<WorkspaceMember> AddWorkspaceMemberAsync(WorkspaceMember workspaceMember, CancellationToken cancellationToken)
    {
        var result = await context.Set<WorkspaceMember>().AddAsync(workspaceMember, cancellationToken);
        
        return result.Entity;
    }
}