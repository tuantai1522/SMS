using FluentValidation;
using SMS.Core.Errors.Projects;
using SMS.Core.Errors.Workspaces;
using SMS.UseCases.Features.Workspaces.UpdateWorkspace;

namespace SMS.UseCases.Features.Projects.UpdateProject;

internal sealed class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.IdEmpty.ToString())
            .WithMessage("Id can not be empty.");
        
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.NameEmpty.ToString())
            .WithMessage("Name can not be empty.");
                
        RuleFor(c => c.Code)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.CodeEmpty.ToString())
            .WithMessage("Code can not be empty.");
    }
}
