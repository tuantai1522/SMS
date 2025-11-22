using SMS.UseCases.Pagination.OffsetPagination;

namespace SMS.UseCases.Features.Workspaces.GetMembersByWorkspaceId;

public sealed class GetMembersByWorkspaceIdQuery(Guid workspaceId) : OffsetPaginationRequest<GetMembersByWorkspaceIdResponse>
{
    public Guid WorkspaceId { get; } = workspaceId;
}
