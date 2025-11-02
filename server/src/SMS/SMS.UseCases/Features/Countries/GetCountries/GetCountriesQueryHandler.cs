using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Countries;

namespace SMS.UseCases.Features.Countries.GetCountries;

public class GetCountriesQueryHandler(ICountryRepository countryRepository) : IRequestHandler<GetCountriesQuery, Result<IReadOnlyList<CountryResponse>>>
{
    public async Task<Result<IReadOnlyList<CountryResponse>>> Handle(GetCountriesQuery query,
        CancellationToken cancellationToken)
    {
        var countries = await countryRepository.GetCountriesAsync(cancellationToken);

        IReadOnlyList<CountryResponse> result = countries
            .Select(country => new CountryResponse(country.Id, country.Name))
            .ToList();

        return Result.Success(result);
    }
}