using SMS.Core.Features.Workspaces;

namespace SMS.UseCases.Queries.Workspaces;

public interface IGetWorkspaceMemberByWorkspaceIdAndUserIdService
{
    Task<WorkspaceMember?> Handle(Guid workspaceId, Guid userId, CancellationToken cancellationToken);
}