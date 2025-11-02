namespace SMS.Core.Features.Countries;

public interface ICountryRepository
{
    Task<IReadOnlyList<Country>> GetCountriesAsync(CancellationToken cancellationToken);
    
    Task<IReadOnlyList<City>> GetCitiesByCountryIdAsync(int countryId, CancellationToken cancellationToken);
}