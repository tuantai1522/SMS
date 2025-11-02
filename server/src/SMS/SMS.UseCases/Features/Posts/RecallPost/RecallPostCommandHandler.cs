using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Posts;
using SMS.Core.Features.Posts;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.UseCases.Features.Posts.RecallPost;

internal sealed class RecallPostCommandHandler(
    IUserProvider userProvider,
    IUnitOfWork unitOfWork,
    IPostRepository postRepository): IRequestHandler<RecallPostCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(RecallPostCommand command, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (post is null)
        {
            return Result.Failure<Guid>(PostErrors.CanNotFindPost);
        }
        
        var userId = userProvider.UserId;
        
        var result = post.Recall(userId);

        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(post.Id);
    }
}
