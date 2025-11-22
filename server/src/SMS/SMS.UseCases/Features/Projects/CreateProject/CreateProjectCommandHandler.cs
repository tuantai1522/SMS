using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Projects;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Projects.CreateProject;

internal sealed class CreateProjectCommandHandler(
    IUserProvider userProvider,
    IUnitOfWork unitOfWork,
    IRepository<Project> projectRepository): IRequestHandler<CreateProjectCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        var userId = userProvider.UserId;
        
        var project = Project.CreateProject(command.Name, command.Code, command.Emoji, command.Description, command.WorkspaceId, userId);
        
        await projectRepository.AddAsync(project, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(project.Id);
    }
}
