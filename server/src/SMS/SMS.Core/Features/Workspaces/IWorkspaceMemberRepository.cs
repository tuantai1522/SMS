namespace SMS.Core.Features.Workspaces;

public interface IWorkspaceMemberRepository
{
    Task<WorkspaceMember> AddWorkspaceMemberAsync(WorkspaceMember workspaceMember, CancellationToken cancellationToken);
}