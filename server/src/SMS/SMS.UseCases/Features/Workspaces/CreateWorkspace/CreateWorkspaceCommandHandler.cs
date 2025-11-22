using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Workspaces.CreateWorkspace;

internal sealed class CreateWorkspaceCommandHandler(
    IUserProvider userProvider,
    IUnitOfWork unitOfWork,
    IRepository<Workspace> workspaceRepository): IRequestHandler<CreateWorkspaceCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateWorkspaceCommand command, CancellationToken cancellationToken)
    {
        var workspace = Workspace.CreateWorkspace(command.Name, command.Description, userProvider.UserId);
        
        await workspaceRepository.AddAsync(workspace, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(workspace.Id);
    }
}
