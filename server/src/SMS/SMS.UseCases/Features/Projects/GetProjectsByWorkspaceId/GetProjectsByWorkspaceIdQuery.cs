using SMS.UseCases.Pagination.OffsetPagination;

namespace SMS.UseCases.Features.Projects.GetProjectsByWorkspaceId;

public sealed class GetProjectsByWorkspaceIdQuery(Guid workspaceId) : OffsetPaginationRequest<GetProjectsByWorkspaceIdResponse>
{
    public Guid WorkspaceId { get; } = workspaceId;
}
