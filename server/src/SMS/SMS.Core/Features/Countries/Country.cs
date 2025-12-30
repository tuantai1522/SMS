using SMS.Core.Common;

namespace SMS.Core.Features.Countries;

public sealed class Country : AggregateRoot
{
    public int Id { get; init; }
    
    public string Name { get; private set; } = null!;

    private Country()
    {
        
    }

    /// <summary>
    /// Create new country
    /// </summary>
    /// <returns></returns>
    public static Country Create(string name)
    {
        return new Country
        {
            Name = name,
        };
    }
}