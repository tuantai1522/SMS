using SMS.Core.Common;
using SMS.Core.Errors.Posts;

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
    
    private const long ValidTimeToRecallMessage = 5 * 60 * 1000; // 5 minutes
    private const long ValidTimeToEditMessage = 15 * 60 * 1000; // 15 minutes
    
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

    public Result Edit(string message, Guid userId)
    {
        if (userId != UserId)
        {
            return Result.Failure(PostErrors.DoNotHavePermissionToEditThisMessage);
        }
        
        // Time to edit is more than "Valid time to edit"
        if (!CanEditMessage())
        {
            return Result.Failure(PostErrors.ThisMessageCanNotEditAnymore);
        }

        Message = message;
        
        // Todo: To add into interceptors
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        return Result.Success();
    }
    
    public Result Recall(Guid userId)
    {
        if (userId != UserId)
        {
            return Result.Failure(PostErrors.DoNotHavePermissionToRecallThisMessage);
        }
        
        // Time to recall is more than "Valid time to recall"
        if (!CanRecallMessage())
        {
            return Result.Failure(PostErrors.ThisMessageCanNotRecallAnymore);
        }

        Message = string.Empty;
        
        DeletedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        return Result.Success();
    }

    private bool CanEditMessage()
    {
        var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        return now - CreatedAt <= ValidTimeToEditMessage;
    }
    
    private bool CanRecallMessage()
    {
        var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        return now - CreatedAt <= ValidTimeToRecallMessage;
    }
}