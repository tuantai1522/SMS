namespace SMS.Core.Features.Projects;

public interface IProjectRepository
{
    Task<Project> AddProjectAsync(Project project, CancellationToken cancellationToken);
    
    Task<Project?> GetProjectByIdAsync(Guid id, CancellationToken cancellationToken);
}