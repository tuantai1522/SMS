using FluentValidation;
using SMS.Core.Errors.Projects;
namespace SMS.UseCases.Features.Projects.GetProjectByIdAndWorkspaceId;

internal sealed class GetProjectByIdAndWorkspaceIdQueryValidator : AbstractValidator<GetProjectByIdAndWorkspaceIdQuery>
{
    public GetProjectByIdAndWorkspaceIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.IdEmpty.ToString())
            .WithMessage("Project Id can not be empty.");
        
        RuleFor(c => c.WorkspaceId)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.WorkspaceIdEmpty.ToString())
            .WithMessage("Workspace Id can not be empty.");
    }
}
