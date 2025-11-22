using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Features.Workspaces.GetWorkspaces;

namespace SMS.Infrastructure.Queries.Workspaces;

public sealed class GetWorkspacesService(IApplicationDbContext context) : IGetWorkspacesService
{
    public async Task<IReadOnlyList<GetWorkspacesResponse>> Handle(Guid userId, CancellationToken cancellationToken)
    {
        return await context.Set<WorkspaceMember>()
            .Where(wm => wm.UserId == userId && !wm.DeletedAt.HasValue)
            .Join(
                context.Set<Workspace>(),
                wm => wm.WorkspaceId,
                w => w.Id,
                (wm, w) => new { wm, w }
            )
            .OrderByDescending(x => x.wm.CreatedAt)
            .Select(x => new GetWorkspacesResponse(x.w.Id, x.w.Name))
            .ToListAsync(cancellationToken);
    }
}