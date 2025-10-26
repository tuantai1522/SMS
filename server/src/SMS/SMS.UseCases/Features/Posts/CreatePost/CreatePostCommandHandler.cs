using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Posts;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.UseCases.Features.Posts.CreatePost;

internal sealed class CreatePostCommandHandler(
    IUserProvider userProvider,
    IUnitOfWork unitOfWork,
    IPostRepository postRepository): IRequestHandler<CreatePostCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var userId = userProvider.UserId;
        
        var post = Post.CreatePost(command.ChannelId, userId, command.RootId, command.Message, PostType.Normal);
        
        await postRepository.AddPostAsync(post, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(post.Id);
    }
}
