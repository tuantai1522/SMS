using FluentValidation;
using SMS.Core.Errors.Teams;

namespace SMS.UseCases.Features.Teams.CreateTeam;

internal sealed class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    public CreateTeamCommandValidator()
    {
        RuleFor(c => c.DisplayName)
            .NotEmpty()
            .WithErrorCode(TeamErrorCode.DisplayNameEmpty.ToString())
            .WithMessage("DisplayName can not be empty.");

        RuleFor(c => c.OwnerIds)
            .NotNull()
            .WithErrorCode(TeamErrorCode.OwnerIdsNull.ToString())
            .WithMessage("OwnerIds can not be null.");
        
        RuleFor(c => c.MemberIds)
            .NotNull()
            .WithErrorCode(TeamErrorCode.MemberIdsNull.ToString())
            .WithMessage("MemberIds can not be null.");
    }
}
