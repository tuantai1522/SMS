using SMS.Core.Features.Projects;

namespace SMS.UseCases.Queries.Projects;

public interface IGetProjectByIdAndLockService
{
    Task<Project?> Handle(Guid id, CancellationToken cancellationToken);
}