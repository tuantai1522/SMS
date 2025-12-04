using FluentValidation;
using SMS.Core.Errors.Projects;

namespace SMS.UseCases.Features.Projects.GetProjectsByWorkspaceId;

internal sealed class GetProjectsByWorkspaceIdQueryValidator : AbstractValidator<GetProjectsByWorkspaceIdQuery>
{
    public GetProjectsByWorkspaceIdQueryValidator()
    {
        RuleFor(c => c.WorkspaceId)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.WorkspaceIdEmpty.ToString())
            .WithMessage("Workspace Id can not be empty.");
        
        RuleFor(c => c.Page)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.InvalidPage.ToString())
            .WithMessage("Page must be positive integer.");
        
        RuleFor(c => c.PageSize)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.InvalidPageSize.ToString())
            .WithMessage("Page size must be positive integer.");
    }
}
