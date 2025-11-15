namespace SMS.Core.Features.Workspaces;

public interface IWorkspaceRepository
{
    Task<Workspace> AddWorkspaceAsync(Workspace workspace, CancellationToken cancellationToken);
    
    Task<Workspace?> GetWorkspaceByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IReadOnlyList<Workspace>> GetWorkspacesByUserIdAsync(Guid userId, CancellationToken cancellationToken);

}