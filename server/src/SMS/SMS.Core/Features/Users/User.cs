using SMS.Core.Common;

namespace SMS.Core.Features.Users;

public sealed class User : AggregateRoot, IDateTracking
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

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
    
    private User() { }

    public static User CreateUser(string firstName, string? middleName, string? lastName, string nickName, string email,
        string password, DateOnly dateOfBirth, GenderType genderType, string street, int cityId)
    {
        return new User
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
    }
}