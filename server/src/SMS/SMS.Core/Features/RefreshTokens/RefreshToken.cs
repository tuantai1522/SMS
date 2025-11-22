using SMS.Core.Common;

namespace SMS.Core.Features.RefreshTokens;

public sealed class RefreshToken : AggregateRoot
{
    public string Token { get; private set; } = null!;
    
    public Guid UserId { get; private set; }
    
    public long ExpiredAt { get; private set; }

    private RefreshToken()
    {
        
    }

    internal static RefreshToken Create(string token, Guid userId, long expiredAt)
    {
        return new RefreshToken
        {
            Token = token,
            UserId = userId,
            ExpiredAt = expiredAt,
        };
    }

    internal void Update(string token, long expiredAt)
    {
        Token = token;
        ExpiredAt = expiredAt;
    }
}