using FluentValidation;
using SMS.Core.Errors.Workspaces;

namespace SMS.UseCases.Features.Workspaces.GetWorkspaceById;

internal sealed class GetWorkspaceByIdQueryValidator : AbstractValidator<GetWorkspaceByIdQuery>
{
    public GetWorkspaceByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(WorkspaceErrorCode.WorkspaceIdEmpty.ToString())
            .WithMessage("Workspace Id can not be empty.");
    }
}
