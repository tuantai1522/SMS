using SMS.Core.Features.Workspaces;

namespace SMS.UseCases.Queries.Workspaces;

public interface IGetMenuViewsByRoleIdService
{
    Task<IReadOnlyList<View>> Handle(Guid roleId, CancellationToken cancellationToken);
}