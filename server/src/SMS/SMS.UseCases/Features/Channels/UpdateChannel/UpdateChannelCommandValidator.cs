using FluentValidation;

namespace SMS.UseCases.Features.Channels.UpdateChannel;

internal sealed class UpdateChannelCommandValidator : AbstractValidator<UpdateChannelCommand>
{
    public UpdateChannelCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id can not be empty.");
        
        RuleFor(c => c.DisplayName)
            .NotEmpty().WithMessage("DisplayName can not be empty.");
    }
}
