namespace SMS.Core.Features.Channels;

public interface IChannelRepository
{
    Task<IReadOnlyList<Channel>> GetChannelsByUserIdAndTeamIdAsync(Guid userId, Guid teamId, CancellationToken cancellationToken);
    
    Task<Channel?> FindChannelByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Channel> AddChannelAsync(Channel channel, CancellationToken cancellationToken);
}