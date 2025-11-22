namespace SMS.UseCases.Features.Workspaces.GetWorkspaces;

public interface IGetWorkspacesService
{
    Task<IReadOnlyList<GetWorkspacesResponse>> Handle(Guid userId, CancellationToken cancellationToken);
}