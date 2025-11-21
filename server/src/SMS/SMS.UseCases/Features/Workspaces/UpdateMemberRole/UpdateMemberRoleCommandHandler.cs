using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Roles;
using SMS.Core.Errors.Workspaces;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Workspaces.UpdateMemberRole;

internal sealed class UpdateMemberRoleCommandHandler(
    IUnitOfWork unitOfWork,
    IRoleRepository roleRepository,
    IWorkspaceMemberRepository workspaceMemberRepository,
    IWorkspaceRepository workspaceRepository): IRequestHandler<UpdateMemberRoleCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateMemberRoleCommand command, CancellationToken cancellationToken)
    {
        var workspace = await workspaceRepository.GetWorkspaceByIdAsync(command.WorkspaceId, cancellationToken);

        if (workspace is null)
        {
            return Result.Failure<bool>(WorkspaceErrors.CanNotFindWorkspace);
        }
        
        var role = await roleRepository.GetRoleByIdAsync(command.RoleId, cancellationToken);

        if (role is null)
        {
            return Result.Failure<bool>(RoleErrors.CanNotFindRole);
        }
        
        var workspaceMember = await workspaceMemberRepository.GetWorkspaceMemberByWorkspaceIdAndUserIdAsync(command.WorkspaceId, command.UserId, cancellationToken);

        if (workspaceMember is null)
        {
            return Result.Failure<bool>(WorkspaceErrors.MemberNotFoundInWorkspace);
        }
        
        workspaceMember.UpdateRoleId(command.RoleId);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(true);
    }
}
