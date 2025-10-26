namespace SMS.Core.Features.Posts;

public interface IPostRepository
{
    Task<Post> AddPostAsync(Post post, CancellationToken cancellationToken);
}