using SMS.Core.Features.Workspaces;

namespace SMS.UseCases.Queries.Workspaces;

public interface IGetRoleByWorkspaceIdAndUserIdService
{
    Task<Role?> Handle(Guid workspaceId, Guid userId, CancellationToken cancellationToken);
}