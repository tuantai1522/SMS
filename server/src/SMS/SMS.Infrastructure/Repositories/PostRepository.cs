using Microsoft.EntityFrameworkCore;
using SMS.Core.Common;
using SMS.Core.Features.Posts;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class PostRepository(ApplicationDbContext context) : IPostRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public IUnitOfWork UnitOfWork => _context;

    public async Task<List<Post>> GetPostsByChannelIdAsync(Guid channelId, Guid? rootId, long? createdAt, Guid? lastId, bool isAscending, int pageSize, CancellationToken cancellationToken)
    {
        var query = _context.Set<Post>()
            .Where(post => (rootId.HasValue ? post.RootId == rootId : post.RootId == null) &&
                           post.ChannelId == channelId)
            .AsQueryable();

        if (createdAt.HasValue && lastId.HasValue)
        {
            query = isAscending ? 
                query.Where(x => EF.Functions.GreaterThan(ValueTuple.Create(x.CreatedAt, x.Id), ValueTuple.Create(createdAt, lastId))) : 
                query.Where(x => EF.Functions.LessThan(ValueTuple.Create(x.CreatedAt, x.Id), ValueTuple.Create(createdAt, lastId)));
        }
        
        query = isAscending
            ? query.OrderBy(x => x.CreatedAt).ThenBy(x => x.Id)
            : query.OrderByDescending(x => x.CreatedAt).ThenByDescending(x => x.Id);

        return await query
            // .Take(pageSize + 1)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<Post> AddPostAsync(Post post, CancellationToken cancellationToken)
    {
        var result = await _context.Set<Post>().AddAsync(post, cancellationToken);
        
        return result.Entity;
    }
}