using SMS.Core.Features.Projects;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Features.Projects.GetProjectsByWorkspaceId;
using SMS.UseCases.Pagination.OffsetPagination;
using SMS.UseCases.Queries.Projects;

namespace SMS.Infrastructure.Queries.Projects;

public sealed class GetProjectsByWorkspaceIdService(IApplicationDbContext context) : IGetProjectsByWorkspaceIdService
{
    public async Task<OffsetPaginationResponse<GetProjectsByWorkspaceIdResponse>> Handle(Guid workspaceId, int page, int pageSize, CancellationToken cancellationToken)
    {
        var baseQuery = 
            from p in context.Set<Project>() 
            join w in context.Set<Workspace>() on workspaceId equals w.Id
            join wm in context.Set<WorkspaceMember>() on w.Id equals wm.WorkspaceId
            orderby p.CreatedAt descending
            select new GetProjectsByWorkspaceIdResponse(p.Id, p.Name, p.Emoji);
        
        return await OffsetPaginationResponse<GetProjectsByWorkspaceIdResponse>.CreateAsync(baseQuery, page, pageSize, cancellationToken);
    }
}