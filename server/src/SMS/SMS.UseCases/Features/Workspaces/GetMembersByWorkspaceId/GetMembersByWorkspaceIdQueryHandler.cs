using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Pagination.OffsetPagination;

namespace SMS.UseCases.Features.Workspaces.GetMembersByWorkspaceId;

internal sealed class GetMembersByWorkspaceIdQueryHandler(IGetMembersByWorkspaceIdService getMembersByWorkspaceIdService): IRequestHandler<GetMembersByWorkspaceIdQuery, Result<OffsetPaginationResponse<GetMembersByWorkspaceIdResponse>>>
{
    public async Task<Result<OffsetPaginationResponse<GetMembersByWorkspaceIdResponse>>> Handle(GetMembersByWorkspaceIdQuery query, CancellationToken cancellationToken)
    {
        var result = await getMembersByWorkspaceIdService.Handle(query, cancellationToken);

        return Result.Success(result);
    }
}
