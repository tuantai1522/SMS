using SMS.UseCases.Features.Projects.GetProjectsByWorkspaceId;
using SMS.UseCases.Pagination.OffsetPagination;

namespace SMS.UseCases.Queries.Projects;

public interface IGetProjectsByWorkspaceIdService
{
    Task<OffsetPaginationResponse<GetProjectsByWorkspaceIdResponse>> Handle(Guid workspaceId, int page, int pageSize, CancellationToken cancellationToken);
}