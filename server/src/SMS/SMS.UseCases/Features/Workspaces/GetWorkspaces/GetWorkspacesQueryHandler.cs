using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.UseCases.Features.Workspaces.GetWorkspaces;

internal sealed class GetWorkspacesQueryHandler(
    IUserProvider userProvider,
    IGetWorkspacesService getWorkspacesService): IRequestHandler<GetWorkspacesQuery, Result<IReadOnlyList<GetWorkspacesResponse>>>
{
    public async Task<Result<IReadOnlyList<GetWorkspacesResponse>>> Handle(GetWorkspacesQuery query, CancellationToken cancellationToken)
    {
        var workspaces = await getWorkspacesService.Handle(userProvider.UserId, cancellationToken);
        
        return Result.Success(workspaces);
    }
}
