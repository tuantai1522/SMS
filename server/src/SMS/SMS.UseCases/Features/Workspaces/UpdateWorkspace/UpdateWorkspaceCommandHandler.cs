using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Workspaces;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Workspaces.UpdateWorkspace;

internal sealed class UpdateWorkspaceCommandHandler(
    IUnitOfWork unitOfWork,
    IRepository<Workspace> workspaceRepository): IRequestHandler<UpdateWorkspaceCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(UpdateWorkspaceCommand command, CancellationToken cancellationToken)
    {
        var workspace = await workspaceRepository.FindByIdAsync(command.Id, cancellationToken);

        if (workspace is null)
        {
            return Result.Failure<Guid>(WorkspaceErrors.CanNotFindWorkspace);
        }
        
        workspace.Update(command.Name, command.Description);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(workspace.Id);
    }
}
