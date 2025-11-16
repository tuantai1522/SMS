using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Projects;
using SMS.UseCases.Abstractions.Data;

namespace SMS.Infrastructure.Repositories;

public sealed class ProjectRepository(IApplicationDbContext context) : IProjectRepository
{
    public async Task<Project> AddProjectAsync(Project workspace, CancellationToken cancellationToken)
    {
        var result = await context.Set<Project>().AddAsync(workspace, cancellationToken);
        
        return result.Entity;
    }

    public async Task<Project?> GetProjectByIdAndWorkspaceIdAsync(Guid id, Guid workspaceId, CancellationToken cancellationToken)
    {
        return await context.Set<Project>()
            .FirstOrDefaultAsync(p => p.Id == id && 
                                      p.WorkspaceId == workspaceId && 
                                      !p.DeletedAt.HasValue, cancellationToken);
    }
}