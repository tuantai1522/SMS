using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.RefreshTokens;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class RefreshTokenRepository(ApplicationDbContext context) : IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetRefreshTokenByToken(string? token, CancellationToken cancellationToken)
    {
        return await context.Set<RefreshToken>()
            .Where(c => c.Token == token)
            .FirstOrDefaultAsync(cancellationToken);
    }
}