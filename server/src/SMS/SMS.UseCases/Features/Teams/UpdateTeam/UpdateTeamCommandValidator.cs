using FluentValidation;

namespace SMS.UseCases.Features.Teams.UpdateTeam;

internal sealed class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
{
    public UpdateTeamCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id can not be empty.");
        
        RuleFor(c => c.DisplayName)
            .NotEmpty().WithMessage("DisplayName can not be empty.");
    }
}
