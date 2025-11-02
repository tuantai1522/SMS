namespace SMS.Core.Features.RefreshTokens;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetRefreshTokenByToken(string? token, CancellationToken cancellationToken);
}