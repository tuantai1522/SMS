using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Workspaces.CreateWorkspace;

internal sealed class AddOwnerOnWorkspaceCreatedDomainEventHandler(
    IRoleRepository roleRepository,
    IRepository<Workspace> workspaceRepository,
    IUnitOfWork unitOfWork) : INotificationHandler<WorkspaceCreatedDomainEvent>
{
    public async Task Handle(WorkspaceCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var ownerRole = await roleRepository.FindRoleByNameAsync(nameof(RoleConstant.Owner), cancellationToken);

        if (ownerRole is null)
        {
            return;
        }
        
        var workspace = await workspaceRepository.FindByIdAsync(notification.WorkspaceId, cancellationToken);
        if (workspace is null)
        {
            return;
        }
        
        workspace.AddMember(notification.UserId, ownerRole.Id);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
