using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Users;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<User?> FindUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await context.Set<User>()
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<User?> FindUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<User>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);    
    }

    public async Task<bool> VerifyExistedEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await context.Set<User>()
            .AnyAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<bool> VerifyExistedNickNameAsync(string nickName, CancellationToken cancellationToken)
    {
        return await context.Set<User>()
            .AnyAsync(x => x.NickName == nickName, cancellationToken);
    }

    public async Task<bool> VerifyExistedUserIdsAsync(IReadOnlyList<Guid> userIds, CancellationToken cancellationToken)
    {
        return await context.Set<User>()
            .AnyAsync(x => !userIds.Contains(x.Id), cancellationToken);    
    }

    public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken)
    {
        var result = await context.Set<User>().AddAsync(user, cancellationToken);
        
        return result.Entity;
    }
}