using FluentValidation;

namespace SMS.UseCases.Features.Posts.CreatePost;

internal sealed class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(c => c.ChannelId)
            .NotEmpty().WithMessage("ChannelId can not be empty.");

        RuleFor(c => c.Message)
            .NotNull().WithMessage("Message can not be null.");
    }
}
