using SMS.Core.Features.Users;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Features.Workspaces.GetMembersByWorkspaceId;
using SMS.UseCases.Pagination.OffsetPagination;
using SMS.UseCases.Queries.Workspaces;

namespace SMS.Infrastructure.Queries.Workspaces;

public sealed class GetMembersByWorkspaceIdService(IApplicationDbContext context) : IGetMembersByWorkspaceIdService
{
    public async Task<OffsetPaginationResponse<GetMembersByWorkspaceIdResponse>> Handle(GetMembersByWorkspaceIdQuery query, CancellationToken cancellationToken)
    {
        var baseQuery =
            from m in context.Set<WorkspaceMember>()
            join u in context.Set<User>() on m.UserId equals u.Id
            join r in context.Set<Role>() on m.RoleId equals r.Id
            join up in context.Set<UserProfile>() on u.Id equals up.UserId
            where m.WorkspaceId == query.WorkspaceId &&
                  !m.DeletedAt.HasValue
            orderby m.CreatedAt descending
            select new GetMembersByWorkspaceIdResponse(u.Id, up.GivenName, u.Email, r.Id, r.Name, m.CreatedAt);

        return await OffsetPaginationResponse<GetMembersByWorkspaceIdResponse>.CreateAsync(
            baseQuery,
            query.Page,
            query.PageSize,
            cancellationToken
        );
    }
}