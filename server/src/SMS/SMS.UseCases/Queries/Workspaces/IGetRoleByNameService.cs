using SMS.Core.Features.Workspaces;

namespace SMS.UseCases.Queries.Workspaces;

public interface IGetRoleByNameService
{
    Task<Role?> Handle(string name, CancellationToken cancellationToken);
}