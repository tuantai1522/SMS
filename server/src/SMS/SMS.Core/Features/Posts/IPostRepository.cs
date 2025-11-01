namespace SMS.Core.Features.Posts;

public interface IPostRepository
{
    Task<List<Post>> GetPostsByChannelIdAsync(Guid channelId, Guid? rootId, long? createdAt, Guid? lastId, bool isAscending, int pageSize, CancellationToken cancellationToken);
    
    Task<Post> AddPostAsync(Post post, CancellationToken cancellationToken);
}