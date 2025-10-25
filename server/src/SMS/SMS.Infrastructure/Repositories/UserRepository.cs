using Microsoft.EntityFrameworkCore;
using SMS.Core.Common;
using SMS.Core.Features.Users;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public IUnitOfWork UnitOfWork => _context;

    public async Task<User?> FindUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Set<User>()
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<bool> VerifyExistedEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Set<User>()
            .AnyAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<bool> VerifyExistedNickNameAsync(string nickName, CancellationToken cancellationToken)
    {
        return await _context.Set<User>()
            .AnyAsync(x => x.NickName == nickName, cancellationToken);
    }

    public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken)
    {
        var result = await _context.Set<User>().AddAsync(user, cancellationToken);
        
        return result.Entity;
    }
}