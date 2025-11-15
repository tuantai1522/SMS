using FluentValidation;
using SMS.Core.Errors.Workspaces;

namespace SMS.UseCases.Features.Workspaces.UpdateWorkspace;

internal sealed class UpdateWorkspaceCommandValidator : AbstractValidator<UpdateWorkspaceCommand>
{
    public UpdateWorkspaceCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(WorkspaceErrorCode.WorkspaceIdEmpty.ToString())
            .WithMessage("Workspace Id can not be empty.");
        
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithErrorCode(WorkspaceErrorCode.NameEmpty.ToString())
            .WithMessage("Name can not be empty.");
    }
}
