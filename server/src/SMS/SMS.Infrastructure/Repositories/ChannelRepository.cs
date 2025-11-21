using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Channels;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class ChannelRepository(ApplicationDbContext context) : IChannelRepository
{
    public async Task<IReadOnlyList<Channel>> GetChannelsByUserIdAndTeamIdAsync(Guid userId, Guid teamId, CancellationToken cancellationToken)
    {
        return await context.Set<Channel>()
            .Where(channel => channel.TeamId == teamId && channel.ChannelMembers.Any(m => m.UserId == userId))
            .ToListAsync(cancellationToken);
    }

    public async Task<Channel?> FindChannelByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Channel>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);    
    }

    public async Task<Channel> AddChannelAsync(Channel channel, CancellationToken cancellationToken)
    {
        var result = await context.Set<Channel>().AddAsync(channel, cancellationToken);
        
        return result.Entity;
    }
}