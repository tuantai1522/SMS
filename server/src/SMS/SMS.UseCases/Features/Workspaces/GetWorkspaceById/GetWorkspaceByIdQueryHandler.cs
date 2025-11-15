using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Workspaces;
using SMS.Core.Features.Workspaces;

namespace SMS.UseCases.Features.Workspaces.GetWorkspaceById;

internal sealed class GetWorkspaceByIdQueryHandler(
    IWorkspaceRepository workspaceRepository): IRequestHandler<GetWorkspaceByIdQuery, Result<GetWorkspaceByIdResponse>>
{
    public async Task<Result<GetWorkspaceByIdResponse>> Handle(GetWorkspaceByIdQuery query, CancellationToken cancellationToken)
    {
        var workspace = await workspaceRepository.GetWorkspaceByIdAsync(query.Id, cancellationToken);

        return workspace is null ? 
            Result.Failure<GetWorkspaceByIdResponse>(WorkspaceErrors.CanNotFindWorkspace) : 
            Result.Success(new GetWorkspaceByIdResponse(workspace.Id, workspace.Name, workspace.Description));
    }
}
