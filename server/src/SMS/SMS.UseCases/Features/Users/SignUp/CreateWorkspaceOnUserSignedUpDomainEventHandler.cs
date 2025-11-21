using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Users;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Users.SignUp;

internal sealed class CreateWorkspaceOnUserSignedUpDomainEventHandler(
    IWorkspaceRepository workspaceRepository,
    IUnitOfWork unitOfWork) : INotificationHandler<UserSignedUpDomainEvent>
{
    public async Task Handle(UserSignedUpDomainEvent notification, CancellationToken cancellationToken)
    {
        var workspace = Workspace.CreateWorkspace("My workspace", "My workspace", notification.UserId);
        await workspaceRepository.AddWorkspaceAsync(workspace, cancellationToken);
            
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
