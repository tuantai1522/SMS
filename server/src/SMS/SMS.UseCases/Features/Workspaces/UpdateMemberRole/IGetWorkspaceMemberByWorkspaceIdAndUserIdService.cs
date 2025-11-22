using SMS.Core.Features.Workspaces;

namespace SMS.UseCases.Features.Workspaces.UpdateMemberRole;

public interface IGetWorkspaceMemberByWorkspaceIdAndUserIdService
{
    Task<WorkspaceMember?> Handle(Guid workspaceId, Guid userId, CancellationToken cancellationToken);
}