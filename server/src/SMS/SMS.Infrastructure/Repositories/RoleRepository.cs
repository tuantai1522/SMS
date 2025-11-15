using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;

namespace SMS.Infrastructure.Repositories;

public sealed class RoleRepository(IApplicationDbContext context) : IRoleRepository
{
    public async Task<Role?> FindRoleByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await context.Set<Role>()
            .FirstOrDefaultAsync(role => role.Name.Equals(name), cancellationToken);
    }

    public async Task<Role?> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Role>()
            .FirstOrDefaultAsync(role => role.Id == id, cancellationToken);
    }
}