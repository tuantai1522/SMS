using SMS.Core.Common;

namespace SMS.Core.Features.Users;

public sealed class UserProfile : BaseEntity, IDateTracking
{
    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;
    
    public string GivenName { get; private set; } = null!;
    public DateOnly DateOfBirth { get; private set; }

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }
    public string? AvatarUrl { get; private set; }

    public GenderType GenderType { get; private set; } = GenderType.Male;
    
    public int CountryId { get; private set; }
    
    private UserProfile() { }

    internal static UserProfile CreateUserProfile(Guid userId, string givenName, DateOnly dateOfBirth, GenderType genderType, string? avatarUrl, int countryId)
    {
        return new UserProfile
        {
            UserId = userId,
            GivenName = givenName,
            DateOfBirth = dateOfBirth,
            GenderType = genderType,
            AvatarUrl = avatarUrl,
            CountryId = countryId
        };
    }
}