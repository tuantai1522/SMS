using FluentValidation;
using SMS.Core.Errors.Posts;

namespace SMS.UseCases.Features.Posts.EditPost;

internal sealed class EditPostCommandValidator : AbstractValidator<EditPostCommand>
{
    public EditPostCommandValidator()
    {
        RuleFor(c => c.PostId)
            .NotEmpty()
            .WithErrorCode(PostErrorCode.PostIdCanNotBeEmpty.ToString())
            .WithMessage("PostId can not be empty.");
        
        RuleFor(c => c.Message)
            .NotEmpty()
            .WithErrorCode(PostErrorCode.MessageCanNotBeEmpty.ToString())
            .WithMessage("Message can not be empty.");
    }
}
