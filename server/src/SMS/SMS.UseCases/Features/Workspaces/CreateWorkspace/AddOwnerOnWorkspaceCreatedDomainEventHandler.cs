using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Workspaces;

namespace SMS.UseCases.Features.Workspaces.CreateWorkspace;

internal sealed class AddOwnerOnWorkspaceCreatedDomainEventHandler(
    IRoleRepository roleRepository,
    IWorkspaceMemberRepository workspaceMemberRepository,
    IUnitOfWork unitOfWork) : INotificationHandler<WorkspaceCreatedDomainEvent>
{
    public async Task Handle(WorkspaceCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var ownerRole = await roleRepository.FindRoleByNameAsync(nameof(RoleConstant.Owner), cancellationToken);

        if (ownerRole is null)
        {
            return;
        }
        
        var workspaceMember = WorkspaceMember.Create(notification.WorkspaceId, notification.UserId, ownerRole.Id);
        
        await workspaceMemberRepository.AddWorkspaceMemberAsync(workspaceMember, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
