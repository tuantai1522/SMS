using FluentValidation;

namespace SMS.UseCases.Features.Channels.CreateChannel;

internal sealed class CreateChannelCommandValidator : AbstractValidator<CreateChannelCommand>
{
    public CreateChannelCommandValidator()
    {
        RuleFor(c => c.DisplayName)
            .NotEmpty().WithMessage("DisplayName can not be empty.");
        
        RuleFor(c => c.TeamId)
            .NotEmpty().WithMessage("TeamId can not be empty.");

        RuleFor(c => c.OwnerIds)
            .NotNull().WithMessage("OwnerIds can not be null.");
        
        RuleFor(c => c.MemberIds)
            .NotNull().WithMessage("MemberIds can not be null.");
    }
}
