using FluentValidation;
using SMS.Core.Errors.Roles;
using SMS.Core.Errors.Users;
using SMS.Core.Errors.Workspaces;
using SMS.UseCases.Features.Workspaces.UpdateWorkspace;

namespace SMS.UseCases.Features.Workspaces.UpdateMemberRole;

internal sealed class UpdateMemberRoleCommandValidator : AbstractValidator<UpdateMemberRoleCommand>
{
    public UpdateMemberRoleCommandValidator()
    {
        RuleFor(c => c.WorkspaceId)
            .NotEmpty()
            .WithErrorCode(WorkspaceErrorCode.WorkspaceIdEmpty.ToString())
            .WithMessage("Workspace Id can not be empty.");
        
        RuleFor(c => c.RoleId)
            .NotEmpty()
            .WithErrorCode(RoleErrorCode.IdEmpty.ToString())
            .WithMessage("Role Id can not be empty.");
        
        RuleFor(c => c.UserId)
            .NotEmpty()
            .WithErrorCode(UserErrorCode.IdEmpty.ToString())
            .WithMessage("User Id can not be empty.");
    }
}
