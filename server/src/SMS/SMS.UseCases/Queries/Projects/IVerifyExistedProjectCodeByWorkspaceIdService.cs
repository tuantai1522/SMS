namespace SMS.UseCases.Queries.Projects;

public interface IVerifyExistedProjectCodeByWorkspaceIdService
{
    Task<bool> Handle(string code, Guid workspaceId, CancellationToken cancellationToken);
}