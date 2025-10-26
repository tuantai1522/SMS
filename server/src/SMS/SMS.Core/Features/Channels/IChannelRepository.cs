namespace SMS.Core.Features.Channels;

public interface IChannelRepository
{
    Task<Channel?> FindChannelByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Channel> AddChannelAsync(Channel channel, CancellationToken cancellationToken);
}