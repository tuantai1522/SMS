using SMS.Core.Common;
using SMS.Core.Features.Posts;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class PostRepository(ApplicationDbContext context) : IPostRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public IUnitOfWork UnitOfWork => _context;

    public async Task<Post> AddPostAsync(Post post, CancellationToken cancellationToken)
    {
        var result = await _context.Set<Post>().AddAsync(post, cancellationToken);
        
        return result.Entity;
    }
}