using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Workspaces.GetMenuViewsByWorkspaceId;

public sealed class GetMenuViewsByWorkspaceIdQuery(Guid workspaceId) : IRequest<Result<IReadOnlyList<GetMenuViewsByWorkspaceIdResponse>>>
{
    public Guid WorkspaceId { get; } = workspaceId;
}
