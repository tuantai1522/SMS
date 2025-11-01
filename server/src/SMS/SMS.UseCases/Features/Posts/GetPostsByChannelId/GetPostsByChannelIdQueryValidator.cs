using FluentValidation;

namespace SMS.UseCases.Features.Posts.GetPostsByChannelId;

internal sealed class GetPostsByChannelIdQueryValidator : AbstractValidator<GetPostsByChannelIdQuery>
{
    public GetPostsByChannelIdQueryValidator()
    {
        RuleFor(c => c.ChannelId)
            .NotEmpty().WithMessage("ChannelId can not be empty.");
        
        RuleFor(c => c.PageSize)
            .GreaterThan(0).WithMessage("PageSize must be positive integer.");
    }
}
