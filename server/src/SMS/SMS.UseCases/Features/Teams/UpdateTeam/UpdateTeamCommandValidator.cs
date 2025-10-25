using FluentValidation;

namespace SMS.UseCases.Features.Teams.UpdateTeam;

internal sealed class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
{
    public UpdateTeamCommandValidator()
    {
        RuleFor(c => c.DisplayName)
            .NotEmpty().WithMessage("Email can not be empty.");
    }
}
