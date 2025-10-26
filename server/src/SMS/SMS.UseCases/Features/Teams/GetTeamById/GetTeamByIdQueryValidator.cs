using FluentValidation;

namespace SMS.UseCases.Features.Teams.GetTeamById;

internal sealed class GetTeamByIdQueryValidator : AbstractValidator<GetTeamByIdQuery>
{
    public GetTeamByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id can not be empty.");
    }
}
