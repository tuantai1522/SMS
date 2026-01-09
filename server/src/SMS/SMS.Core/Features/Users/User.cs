using SMS.Core.Common;
using SMS.Core.Features.RefreshTokens;

namespace SMS.Core.Features.Users;

public sealed class User : AggregateRoot, IDateTracking
{
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }

    public UserStatus Status { get; private set; } = UserStatus.Active;
    
    public string? VerificationToken { get; private set; }
    public long? VerificationTokenExpiredAt { get; private set; }
    
    public UserProfile UserProfile { get; private set; } = null!;

    /// <summary>
    /// List refresh tokens of this user.
    /// </summary>
    private readonly List<RefreshToken> _refreshTokens = [];
    
    public IReadOnlyList<RefreshToken> RefreshTokens => _refreshTokens.ToList();
    
    /// <summary>
    /// List user sign-ins of this user.
    /// </summary>
    private readonly List<UserSignIn> _userSignIns = [];
    
    public IReadOnlyList<UserSignIn> UserSignIns => _userSignIns.ToList();
    
    private User() { }

    public static User CreateUser(string email, string password, UserStatus status, string? verificationToken, long? verificationTokenExpiredAt)
    {
        var user = new User
        {
            Email = email,
            Password = password,
            Status = status,
            VerificationToken = verificationToken,
            VerificationTokenExpiredAt = verificationTokenExpiredAt,
        };
        
        return user;
    }

    public void CreateUserProfile(string givenName, string? avatarUrl)
    {
        UserProfile = UserProfile.CreateUserProfile(Id, givenName, avatarUrl);

        Status = UserStatus.Active;
        RaiseDomainEvent(new UserSignedUpDomainEvent(Id));
    }

    public void UpdateUserProfile(string givenName, string? avatarUrl)
    {
        UserProfile.Update(givenName, avatarUrl);

        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public void AddRefreshToken(string token, long expiredAt)
    {
        _refreshTokens.Add(RefreshToken.Create(token, Id, expiredAt));
    }

    public void UpdateRefreshToken(Guid refreshTokenId, string token, long expiredAt)
    {
        var refreshToken = _refreshTokens.FirstOrDefault(currentToken => currentToken.Id == refreshTokenId);

        refreshToken?.Update(token, expiredAt);
    }
    
    public void AddUserSignIns(ProviderType providerType, string providerKey, string? providerEmail)
    {
        _userSignIns.Add(UserSignIn.CreateUserSignIn(Id, providerType, providerKey, providerEmail));
    }
}