using SMS.UseCases.Features.Countries.GetCountries;

namespace SMS.UseCases.Queries.Countries;

public interface IGetCountriesService
{
    Task<IReadOnlyList<CountryResponse>> Handle(CancellationToken cancellationToken);
}