using SMS.UseCases.Pagination.OffsetPagination;

namespace SMS.UseCases.Features.Workspaces.GetMembersByWorkspaceId;

public interface IGetMembersByWorkspaceIdService
{
    Task<OffsetPaginationResponse<GetMembersByWorkspaceIdResponse>> Handle(GetMembersByWorkspaceIdQuery query, CancellationToken cancellationToken);
}