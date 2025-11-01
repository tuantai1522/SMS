using FluentValidation;
using SMS.Core.Errors.Teams;

namespace SMS.UseCases.Features.Teams.UpdateTeam;

internal sealed class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
{
    public UpdateTeamCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(TeamErrorCode.TeamIdEmpty.ToString())
            .WithMessage("Team Id can not be empty.");
        
        RuleFor(c => c.DisplayName)
            .NotEmpty()
            .WithErrorCode(TeamErrorCode.DisplayNameEmpty.ToString())
            .WithMessage("DisplayName can not be empty.");
    }
}
