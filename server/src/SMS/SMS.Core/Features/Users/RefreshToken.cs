namespace SMS.Core.Features.Users;

public sealed class RefreshToken
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

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

    internal void UpdateExpiredAt(long expiredAt) => ExpiredAt = expiredAt;
    internal void UpdateToken(string token) => Token = token;
}