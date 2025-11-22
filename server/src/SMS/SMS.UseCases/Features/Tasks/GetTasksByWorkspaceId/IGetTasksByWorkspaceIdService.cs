using SMS.UseCases.Pagination.OffsetPagination;

namespace SMS.UseCases.Features.Tasks.GetTasksByWorkspaceId;

public interface IGetTasksByWorkspaceIdService
{
    Task<OffsetPaginationResponse<GetTasksByWorkspaceIdResponse>> Handle(GetTasksByWorkspaceIdQuery query, CancellationToken cancellationToken);
}