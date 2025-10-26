using SMS.Core.Common;

namespace SMS.Core.Features.Posts;

public sealed class Post : AggregateRoot, IDateTracking, ISoftDelete
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    
    public Guid ChannelId { get; init; }
    public Guid UserId { get; init; }
    
    public Guid? RootId { get; init; }
    public Post? Root { get; init; }    

    public string Message { get; private set; } = null!;

    public PostType Type { get; init; } = PostType.Normal;
    

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    public long? UpdatedAt { get; private set; }
    public long? DeletedAt { get; private set; }
    
    
    
    private readonly List<Post> _posts = [];
    public IReadOnlyList<Post> Posts => _posts.ToList();
    
    
    private Post() { }

    public static Post CreatePost(Guid channelId, Guid userId, Guid? rootId, string message, PostType type)
    {
        return new Post
        {
            ChannelId = channelId,
            UserId = userId,
            RootId = rootId,
            Message = message,
            Type = type,
        };
    }

    public void Delete()
    {
        DeletedAt = DeletedAt.HasValue ? null : DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public void Update(string message)
    {
        Message = message;
        
        // Todo: To add into interceptors
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}