using FluentValidation;
using SMS.Core.Errors.Tasks;

namespace SMS.UseCases.Features.Tasks.GetTasksByWorkspaceId;

internal sealed class GetTasksByWorkspaceIdQueryValidator : AbstractValidator<GetTasksByWorkspaceIdQuery>
{
    public GetTasksByWorkspaceIdQueryValidator()
    {
        RuleFor(c => c.WorkspaceId)
            .NotEmpty()
            .WithErrorCode(TaskErrorCode.WorkspaceIdEmpty.ToString())
            .WithMessage("Workspace Id can not be empty.");
        
        RuleFor(c => c.Page)
            .NotEmpty()
            .WithErrorCode(TaskErrorCode.InvalidPage.ToString())
            .WithMessage("Page must be positive integer.");
        
        RuleFor(c => c.PageSize)
            .NotEmpty()
            .WithErrorCode(TaskErrorCode.InvalidPageSize.ToString())
            .WithMessage("Page size must be positive integer.");
    }
}
