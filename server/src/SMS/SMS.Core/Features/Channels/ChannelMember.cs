using SMS.Core.Common;
using SMS.Core.Features.Users;

namespace SMS.Core.Features.Channels;

public sealed class ChannelMember : BaseEntity, IDateTracking, ISoftDelete
{
    public Guid ChannelId { get; init; }
    
    public Guid UserId { get; init; }

    public ChannelMemberRole Role { get; private set; } = ChannelMemberRole.Member;

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }

    private ChannelMember()
    {
    }

    internal static ChannelMember CreateChannelMember(Guid channelId, Guid userId, ChannelMemberRole role)
    {
        return new ChannelMember
        {
            ChannelId = channelId,
            UserId = userId,
            Role = role
        };
    }

    public long? DeletedAt { get; private set; }

    public void Delete()
    {
        DeletedAt = DeletedAt.HasValue ? null : DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}