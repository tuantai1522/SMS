using Microsoft.EntityFrameworkCore;
using SMS.Core.Common;
using SMS.Core.Features.RefreshTokens;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class RefreshTokenRepository(ApplicationDbContext context) : IRefreshTokenRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public IUnitOfWork UnitOfWork => _context;

    public async Task<RefreshToken?> GetRefreshTokenByToken(string? token, CancellationToken cancellationToken)
    {
        return await _context.Set<RefreshToken>()
            .Where(c => c.Token == token)
            .FirstOrDefaultAsync(cancellationToken);
    }
}