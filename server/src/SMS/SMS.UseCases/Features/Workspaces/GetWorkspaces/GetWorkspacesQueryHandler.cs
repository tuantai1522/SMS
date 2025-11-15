using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.UseCases.Features.Workspaces.GetWorkspaces;

internal sealed class GetWorkspacesQueryHandler(
    IUserProvider userProvider,
    IWorkspaceRepository workspaceRepository): IRequestHandler<GetWorkspacesQuery, Result<IReadOnlyList<GetWorkspacesResponse>>>
{
    public async Task<Result<IReadOnlyList<GetWorkspacesResponse>>> Handle(GetWorkspacesQuery command, CancellationToken cancellationToken)
    {
        var workspaces = await workspaceRepository.GetWorkspacesByUserIdAsync(userProvider.UserId, cancellationToken);
        
        IReadOnlyList<GetWorkspacesResponse> result = workspaces.Select(workspace => new GetWorkspacesResponse(workspace.Id, workspace.Name)).ToList();
        
        return Result.Success(result);
    }
}
