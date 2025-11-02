using FluentValidation;
using SMS.Core.Errors.Posts;

namespace SMS.UseCases.Features.Posts.RecallPost;

internal sealed class RecallPostCommandValidator : AbstractValidator<RecallPostCommand>
{
    public RecallPostCommandValidator()
    {
        RuleFor(c => c.PostId)
            .NotEmpty()
            .WithErrorCode(PostErrorCode.PostIdCanNotBeEmpty.ToString())
            .WithMessage("PostId can not be empty.");
    }
}
