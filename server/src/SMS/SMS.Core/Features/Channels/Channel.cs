using SMS.Core.Common;
using SMS.Core.Errors.Teams;

namespace SMS.Core.Features.Channels;

public sealed class Channel : AggregateRoot, IDateTracking, ISoftDelete
{
    public string DisplayName { get; private set; } = null!;
    public string? Description { get; private set; }
    

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    public long? UpdatedAt { get; private set; }
    
    public Guid TeamId { get; private set; }
    
    private readonly List<ChannelMember> _channelMembers = [];
    
    public IReadOnlyList<ChannelMember> ChannelMembers => _channelMembers.ToList();
    
    private Channel() { }

    public static Channel CreateChannel(string displayName, string? description, Guid teamId, IReadOnlyList<Guid> ownerIds, IReadOnlyList<Guid> memberIds)
    {
        var channel = new Channel
        {
            DisplayName = displayName,
            Description = description,
            TeamId = teamId,
        };
        
        // Add owners
        foreach (var ownerId in ownerIds)
        {
            channel.AddChannelMember(ownerId, ChannelMemberRole.Owner);
        }

        // Add members
        foreach (var memberId in memberIds)
        {
            channel.AddChannelMember(memberId, ChannelMemberRole.Member);
        }

        return channel;
    }

    public Result AddChannelMember(Guid userId, ChannelMemberRole role)
    {
        if (_channelMembers.Any(channelMember => channelMember.UserId == userId))
        {
            return Result.Failure(TeamErrors.UserAlreadyExistedInTeam);
        }
        
        _channelMembers.Add(ChannelMember.CreateChannelMember(Id, userId, role));
        
        return Result.Success();
    }

    public long? DeletedAt { get; private set; }
    
    public void Delete()
    {
        DeletedAt = DeletedAt.HasValue ? null : DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
    
    public void Update(string displayName, string? description)
    {
        DisplayName = displayName;
        Description = description;
        
        // Todo: To bring into interceptors
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}