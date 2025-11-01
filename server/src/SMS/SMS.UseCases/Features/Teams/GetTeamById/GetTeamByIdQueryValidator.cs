using FluentValidation;
using SMS.Core.Errors.Teams;

namespace SMS.UseCases.Features.Teams.GetTeamById;

internal sealed class GetTeamByIdQueryValidator : AbstractValidator<GetTeamByIdQuery>
{
    public GetTeamByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(TeamErrorCode.TeamIdEmpty.ToString())
            .WithMessage("Team Id can not be empty.");
    }
}
