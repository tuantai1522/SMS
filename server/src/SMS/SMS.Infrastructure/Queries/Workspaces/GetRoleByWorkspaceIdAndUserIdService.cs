using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Workspaces;
using SMS.Infrastructure.Database;
using SMS.UseCases.Queries.Workspaces;

namespace SMS.Infrastructure.Queries.Workspaces;

public sealed class GetRoleByWorkspaceIdAndUserIdService(ApplicationDbContext context) : IGetRoleByWorkspaceIdAndUserIdService
{
    public async Task<Role?> Handle(Guid workspaceId, Guid userId, CancellationToken cancellationToken)
    {
        return await (
            from m in context.Set<WorkspaceMember>()
            join r in context.Set<Role>() on m.RoleId equals r.Id
            where m.WorkspaceId == workspaceId && 
                  m.UserId == userId && 
                  !m.DeletedAt.HasValue
            select r
        ).FirstOrDefaultAsync(cancellationToken);
    }
}