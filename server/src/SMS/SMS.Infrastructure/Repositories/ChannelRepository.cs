using Microsoft.EntityFrameworkCore;
using SMS.Core.Common;
using SMS.Core.Features.Channels;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class ChannelRepository(ApplicationDbContext context) : IChannelRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public IUnitOfWork UnitOfWork => _context;

    public async Task<Channel?> FindChannelByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<Channel>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);    
    }

    public async Task<Channel> AddChannelAsync(Channel channel, CancellationToken cancellationToken)
    {
        var result = await _context.Set<Channel>().AddAsync(channel, cancellationToken);
        
        return result.Entity;
    }
}