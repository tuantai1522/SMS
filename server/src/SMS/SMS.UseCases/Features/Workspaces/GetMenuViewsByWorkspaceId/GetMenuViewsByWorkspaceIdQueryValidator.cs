using FluentValidation;
using SMS.Core.Errors.Workspaces;

namespace SMS.UseCases.Features.Workspaces.GetMenuViewsByWorkspaceId;

internal sealed class GetMenuViewsByWorkspaceIdQueryValidator : AbstractValidator<GetMenuViewsByWorkspaceIdQuery>
{
    public GetMenuViewsByWorkspaceIdQueryValidator()
    {
        RuleFor(c => c.WorkspaceId)
            .NotEmpty()
            .WithErrorCode(WorkspaceErrorCode.WorkspaceIdEmpty.ToString())
            .WithMessage("Workspace Id can not be empty.");
    }
}
