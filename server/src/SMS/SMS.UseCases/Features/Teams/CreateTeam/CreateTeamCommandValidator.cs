using FluentValidation;

namespace SMS.UseCases.Features.Teams.CreateTeam;

internal sealed class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    public CreateTeamCommandValidator()
    {
        RuleFor(c => c.DisplayName)
            .NotEmpty().WithMessage("Email can not be empty.");

        RuleFor(c => c.OwnerIds)
            .NotNull().WithMessage("OwnerIds can not be null.");
        
        RuleFor(c => c.MemberIds)
            .NotNull().WithMessage("MemberIds can not be null.");
    }
}
