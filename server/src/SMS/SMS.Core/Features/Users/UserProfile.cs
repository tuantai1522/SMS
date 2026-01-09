using SMS.Core.Common;

namespace SMS.Core.Features.Users;

public sealed class UserProfile : BaseEntity, IDateTracking
{
    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;
    
    public string GivenName { get; private set; } = null!;

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }
    public string? AvatarUrl { get; private set; }

    private UserProfile() { }

    internal static UserProfile CreateUserProfile(Guid userId, string givenName, string? avatarUrl)
    {
        return new UserProfile
        {
            UserId = userId,
            GivenName = givenName,
            AvatarUrl = avatarUrl,
        };
    }
    
    internal void Update(string givenName, string? avatarUrl)
    {
        GivenName = givenName;
        AvatarUrl = avatarUrl;
    }
}