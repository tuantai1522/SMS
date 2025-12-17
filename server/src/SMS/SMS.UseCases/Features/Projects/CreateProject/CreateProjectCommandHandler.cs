using MediatR;
using Microsoft.Extensions.Logging;
using SMS.Core.Common;
using SMS.Core.Errors.Projects;
using SMS.Core.Errors.Tasks;
using SMS.Core.Features.Projects;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Exceptions;
using SMS.UseCases.Queries.Projects;

namespace SMS.UseCases.Features.Projects.CreateProject;

internal sealed class CreateProjectCommandHandler(
    IUserProvider userProvider,
    IUnitOfWork unitOfWork,
    IVerifyExistedProjectCodeByWorkspaceIdService verifyExistedProjectCodeByWorkspaceIdService,
    IRepository<Project> projectRepository): IRequestHandler<CreateProjectCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        var verifyExistedCode = await verifyExistedProjectCodeByWorkspaceIdService.Handle(command.Code, command.WorkspaceId, cancellationToken);
        
        if (verifyExistedCode)
        {
            return Result.Failure<Guid>(ProjectErrors.ProjectCodeAlreadyExistedInWorkspace);
        }
        
        var userId = userProvider.UserId;
        
        var project = Project.CreateProject(command.Name, command.Code, command.Emoji, command.Description, command.WorkspaceId, userId);
        
        await projectRepository.AddAsync(project, cancellationToken);
        
        // Try to save
        try
        {
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(project.Id);
        }
        catch (DuplicateKeyException)
        {
            return Result.Failure<Guid>(ProjectErrors.ProjectCodeAlreadyExistedInWorkspace);
        }
    }
}
