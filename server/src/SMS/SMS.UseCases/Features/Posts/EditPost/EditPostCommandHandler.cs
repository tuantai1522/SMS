using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Posts;
using SMS.Core.Features.Posts;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.UseCases.Features.Posts.EditPost;

internal sealed class CreatePostCommandHandler(
    IUserProvider userProvider,
    IUnitOfWork unitOfWork,
    IPostRepository postRepository): IRequestHandler<EditPostCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(EditPostCommand command, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (post is null)
        {
            return Result.Failure<Guid>(PostErrors.CanNotFindPost);
        }
        
        var userId = userProvider.UserId;
        
        var result = post.Edit(command.Message, userId);

        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(post.Id);
    }
}
