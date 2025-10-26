using FluentValidation;

namespace SMS.UseCases.Features.Channels.GetChannelById;

internal sealed class GetChannelByIdQueryValidator : AbstractValidator<GetChannelByIdQuery>
{
    public GetChannelByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id can not be empty.");
    }
}
