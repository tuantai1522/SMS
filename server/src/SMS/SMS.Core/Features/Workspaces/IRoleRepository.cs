namespace SMS.Core.Features.Workspaces;

public interface IRoleRepository
{
    Task<Role?> FindRoleByNameAsync(string name, CancellationToken cancellationToken);
    Task<Role?> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken);
}