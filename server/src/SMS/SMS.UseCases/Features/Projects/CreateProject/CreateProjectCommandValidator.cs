using FluentValidation;
using SMS.Core.Errors.Projects;

namespace SMS.UseCases.Features.Projects.CreateProject;

internal sealed class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.NameEmpty.ToString())
            .WithMessage("Name can not be empty.");
        
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.CodeEmpty.ToString())
            .WithMessage("Code can not be empty.");
        
        RuleFor(c => c.WorkspaceId)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.WorkspaceIdEmpty.ToString())
            .WithMessage("WorkspaceId can not be empty.");
    }
}
