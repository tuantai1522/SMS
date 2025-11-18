using FluentValidation;
using SMS.Core.Errors.Projects;

namespace SMS.UseCases.Features.Projects.GetProjectById;

internal sealed class GetProjectByIdQueryValidator : AbstractValidator<GetProjectByIdQuery>
{
    public GetProjectByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(ProjectErrorCode.IdEmpty.ToString())
            .WithMessage("Project Id can not be empty.");
    }
}
