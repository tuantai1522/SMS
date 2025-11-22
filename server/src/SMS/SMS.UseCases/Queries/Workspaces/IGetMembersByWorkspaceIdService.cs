using SMS.UseCases.Features.Workspaces.GetMembersByWorkspaceId;
using SMS.UseCases.Pagination.OffsetPagination;

namespace SMS.UseCases.Queries.Workspaces;

public interface IGetMembersByWorkspaceIdService
{
    Task<OffsetPaginationResponse<GetMembersByWorkspaceIdResponse>> Handle(GetMembersByWorkspaceIdQuery query, CancellationToken cancellationToken);
}