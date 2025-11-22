using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Pagination.OffsetPagination;
using SMS.UseCases.Queries.Tasks;

namespace SMS.UseCases.Features.Tasks.GetTasksByWorkspaceId;

internal sealed class GetTasksByWorkspaceIdQueryHandler(IGetTasksByWorkspaceIdService getTasksByWorkspaceIdService): IRequestHandler<GetTasksByWorkspaceIdQuery, Result<OffsetPaginationResponse<GetTasksByWorkspaceIdResponse>>>
{
    public async Task<Result<OffsetPaginationResponse<GetTasksByWorkspaceIdResponse>>> Handle(GetTasksByWorkspaceIdQuery query, CancellationToken cancellationToken)
    {
        var result = await getTasksByWorkspaceIdService.Handle(query, cancellationToken);

        return Result.Success(result);
    }
}
