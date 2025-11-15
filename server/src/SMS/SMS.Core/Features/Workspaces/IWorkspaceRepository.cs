namespace SMS.Core.Features.Workspaces;

public interface IWorkspaceRepository
{
    Task<Workspace> AddWorkspaceAsync(Workspace workspace, CancellationToken cancellationToken);
    
    Task<Workspace?> FindWorkspaceByIdAsync(Guid id, CancellationToken cancellationToken);
    
}