namespace SMS.Core.Features.Projects;

public interface IProjectRepository
{
    Task<Project> AddProjectAsync(Project project, CancellationToken cancellationToken);
    
    Task<Project?> GetProjectByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Get project by id and lock that record to insert new task
    /// </summary>
    Task<Project?> GetProjectByIdAndLockAsync(Guid id, CancellationToken cancellationToken);
}