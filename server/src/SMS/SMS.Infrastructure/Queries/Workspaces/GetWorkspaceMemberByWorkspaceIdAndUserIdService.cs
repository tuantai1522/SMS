using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Workspaces;
using SMS.Infrastructure.Database;
using SMS.UseCases.Features.Workspaces.UpdateMemberRole;

namespace SMS.Infrastructure.Queries.Workspaces;

public sealed class GetWorkspaceMemberByWorkspaceIdAndUserIdService(ApplicationDbContext context) : IGetWorkspaceMemberByWorkspaceIdAndUserIdService
{
    public async Task<WorkspaceMember?> Handle(Guid workspaceId, Guid userId, CancellationToken cancellationToken)
    {
        return await context.Set<WorkspaceMember>()
            .FirstOrDefaultAsync(workspaceMember => workspaceMember.WorkspaceId == workspaceId && 
                                                    workspaceMember.UserId == userId && 
                                                    !workspaceMember.DeletedAt.HasValue, cancellationToken);
    }
}