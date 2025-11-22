using SMS.UseCases.Features.Workspaces.GetWorkspaces;

namespace SMS.UseCases.Queries.Workspaces;

public interface IGetWorkspacesService
{
    Task<IReadOnlyList<GetWorkspacesResponse>> Handle(Guid userId, CancellationToken cancellationToken);
}