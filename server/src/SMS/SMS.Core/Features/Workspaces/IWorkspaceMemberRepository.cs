namespace SMS.Core.Features.Workspaces;

public interface IWorkspaceMemberRepository
{
    Task<WorkspaceMember?> GetWorkspaceMemberByWorkspaceIdAndUserIdAsync(Guid workspaceId, Guid userId, CancellationToken cancellationToken);
    
    Task<WorkspaceMember> AddWorkspaceMemberAsync(WorkspaceMember workspaceMember, CancellationToken cancellationToken);
}