using FluentValidation;
using SMS.Core.Errors.Workspaces;

namespace SMS.UseCases.Features.Workspaces.CreateWorkspace;

internal sealed class CreateWorkspaceCommandValidator : AbstractValidator<CreateWorkspaceCommand>
{
    public CreateWorkspaceCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithErrorCode(WorkspaceErrorCode.NameEmpty.ToString())
            .WithMessage("Name can not be empty.");
    }
}
