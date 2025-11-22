using SMS.UseCases.Features.Tasks.GetTasksByWorkspaceId;
using SMS.UseCases.Pagination.OffsetPagination;

namespace SMS.UseCases.Queries.Tasks;

public interface IGetTasksByWorkspaceIdService
{
    Task<OffsetPaginationResponse<GetTasksByWorkspaceIdResponse>> Handle(GetTasksByWorkspaceIdQuery query, CancellationToken cancellationToken);
}