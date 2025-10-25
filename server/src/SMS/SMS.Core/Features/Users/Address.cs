using SMS.Core.Features.Countries;

namespace SMS.Core.Features.Users;

public sealed class Address
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;

    public string? Street { get; private set; }

    public int CityId { get; private set; }
    public City City { get; private set; } = null!;
    
    private Address() { }

    internal static Address CreateAddress(string street, int cityId)
    {
        return new Address
        {
            CityId = cityId,
            Street = street,
        };
    }
}