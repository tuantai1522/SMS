using FluentValidation;
using SMS.Core.Errors.Tasks;
using SMS.Core.Errors.Workspaces;

namespace SMS.UseCases.Features.Workspaces.GetMembersByWorkspaceId;

internal sealed class GetMembersByWorkspaceIdQueryValidator : AbstractValidator<GetMembersByWorkspaceIdQuery>
{
    public GetMembersByWorkspaceIdQueryValidator()
    {
        RuleFor(c => c.WorkspaceId)
            .NotEmpty()
            .WithErrorCode(WorkspaceErrorCode.WorkspaceIdEmpty.ToString())
            .WithMessage("Workspace Id can not be empty.");
        
        RuleFor(c => c.Page)
            .NotEmpty()
            .WithErrorCode(WorkspaceErrorCode.InvalidPage.ToString())
            .WithMessage("Page must be positive integer.");
        
        RuleFor(c => c.PageSize)
            .NotEmpty()
            .WithErrorCode(WorkspaceErrorCode.InvalidPageSize.ToString())
            .WithMessage("Page size must be positive integer.");
    }
}
