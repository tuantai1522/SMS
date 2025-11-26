using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Workspaces;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Queries.Workspaces;

namespace SMS.UseCases.Features.Workspaces.GetMenuViewsByWorkspaceId;

internal sealed class GetMenuViewsByWorkspaceIdQueryHandler(
    IUserProvider userProvider,
    IGetMenuViewsByRoleIdService getMenuViewsByRoleIdService,
    IGetRoleByWorkspaceIdAndUserIdService getRoleByWorkspaceIdAndUserIdService): IRequestHandler<GetMenuViewsByWorkspaceIdQuery, Result<IReadOnlyList<GetMenuViewsByWorkspaceIdResponse>>>
{
    public async Task<Result<IReadOnlyList<GetMenuViewsByWorkspaceIdResponse>>> Handle(GetMenuViewsByWorkspaceIdQuery query, CancellationToken cancellationToken)
    {
        var role = await getRoleByWorkspaceIdAndUserIdService.Handle(query.WorkspaceId, userProvider.UserId, cancellationToken);

        if (role == null)
        {
            return Result.Failure<IReadOnlyList<GetMenuViewsByWorkspaceIdResponse>>(WorkspaceErrors.MemberNotFoundInWorkspace);
        }
        
        var views = await getMenuViewsByRoleIdService.Handle(role.Id, cancellationToken);
        
        IReadOnlyList<GetMenuViewsByWorkspaceIdResponse> result = views
            .Select(v => new GetMenuViewsByWorkspaceIdResponse(v.Id, v.Name, v.Code, v.Vid, v.Icon)).ToList();
        
        return Result.Success(result);
    }
}
