using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Queries.Workspaces;

namespace SMS.Infrastructure.Queries.Workspaces;

public sealed class GetRoleByNameService(IApplicationDbContext context) : IGetRoleByNameService
{
    public async Task<Role?> Handle(string name, CancellationToken cancellationToken)
    {
        return await context.Set<Role>()
            .FirstOrDefaultAsync(role => role.Name.Equals(name), cancellationToken);
    }
}