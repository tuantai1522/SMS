using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Projects;
using SMS.Core.Features.Projects;

namespace SMS.UseCases.Features.Projects.UpdateProject;

internal sealed class UpdateProjectCommandHandler(
    IUnitOfWork unitOfWork,
    IProjectRepository projectRepository): IRequestHandler<UpdateProjectCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
    {
        var project = await projectRepository.GetProjectByIdAndWorkspaceIdAsync(command.Id, command.WorkspaceId, cancellationToken);

        if (project is null)
        {
            return Result.Failure<Guid>(ProjectErrors.CanNotFindProject);
        }
        
        project.Update(command.Name, command.Code, command.Emoji, command.Description);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(project.Id);
    }
}
