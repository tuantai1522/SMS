using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Projects;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Queries.Projects;

namespace SMS.Infrastructure.Queries.Projects;

public sealed class GetProjectByIdAndLockService(IApplicationDbContext context) : IGetProjectByIdAndLockService
{
    public async Task<Project?> Handle(Guid id, CancellationToken cancellationToken)
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