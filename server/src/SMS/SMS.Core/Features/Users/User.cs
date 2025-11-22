using SMS.Core.Common;
using SMS.Core.Features.RefreshTokens;

namespace SMS.Core.Features.Users;

public sealed class User : AggregateRoot, IDateTracking
{
    public string FirstName { get; private set; } = null!;
    public string? MiddleName { get; private set; }
    public string? LastName { get; private set; }
    public string NickName { get; private set; } = null!;

    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;

    public DateOnly DateOfBirth { get; private set; }

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }
    
    public Address? Address { get; private set; }

    public GenderType GenderType { get; private set; } = GenderType.Male;
    
    /// <summary>
    /// List refresh tokens of this user.
    /// </summary>
    private readonly List<RefreshToken> _refreshTokens = [];
    
    public IReadOnlyList<RefreshToken> RefreshTokens => _refreshTokens.ToList();
    
    private User() { }

    public static User CreateUser(string firstName, string? middleName, string? lastName, string nickName, string email,
        string password, DateOnly dateOfBirth, GenderType genderType, string street, int cityId)
    {
        var user = new User
        {
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            NickName = nickName,
            Email = email,
            Password = password,
            DateOfBirth = dateOfBirth,
            GenderType = genderType,
            Address = Address.CreateAddress(street, cityId)
        };

        // Raise domain event 
        user.RaiseDomainEvent(new UserSignedUpDomainEvent(user.Id));
        
        return user;
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
}