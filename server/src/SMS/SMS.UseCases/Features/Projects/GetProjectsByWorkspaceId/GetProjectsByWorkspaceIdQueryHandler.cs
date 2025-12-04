using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Pagination.OffsetPagination;
using SMS.UseCases.Queries.Projects;

namespace SMS.UseCases.Features.Projects.GetProjectsByWorkspaceId;

internal sealed class GetProjectsByWorkspaceIdQueryHandler(
    IGetProjectsByWorkspaceIdService getProjectsByWorkspaceIdService) : IRequestHandler<GetProjectsByWorkspaceIdQuery, Result<OffsetPaginationResponse<GetProjectsByWorkspaceIdResponse>>>
{
    public async Task<Result<OffsetPaginationResponse<GetProjectsByWorkspaceIdResponse>>> Handle(GetProjectsByWorkspaceIdQuery query, CancellationToken cancellationToken)
    {
        return  await getProjectsByWorkspaceIdService.Handle(query.WorkspaceId, query.Page, query.PageSize, cancellationToken);
    }
}
