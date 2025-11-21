using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Projects;
using SMS.UseCases.Abstractions.Data;

namespace SMS.Infrastructure.Repositories;

public sealed class ProjectRepository(IApplicationDbContext context) : IProjectRepository
{
    public async Task<Project> AddProjectAsync(Project project, CancellationToken cancellationToken)
    {
        var result = await context.Set<Project>().AddAsync(project, cancellationToken);
        
        return result.Entity;
    }

    public async Task<Project?> GetProjectByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Project>()
            .FirstOrDefaultAsync(p => p.Id == id && !p.DeletedAt.HasValue, cancellationToken);
    }

    public async Task<Project?> GetProjectByIdAndLockAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Project>()
            .FromSql(
            $@"
                SELECT *
                FROM sms.""projects""
                WHERE ""id"" = {id}
                FOR UPDATE
            ")
            .FirstOrDefaultAsync(cancellationToken);
    }
}