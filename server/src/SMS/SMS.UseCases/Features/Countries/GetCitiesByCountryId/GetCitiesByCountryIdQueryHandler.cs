using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Countries;

namespace SMS.UseCases.Features.Countries.GetCitiesByCountryId;

public class GetCitiesByCountryIdQueryHandler(ICountryRepository countryRepository)
    : IRequestHandler<GetCitiesByCountryIdQuery, Result<IReadOnlyList<CityResponse>>>
{
    public async Task<Result<IReadOnlyList<CityResponse>>> Handle(GetCitiesByCountryIdQuery query,
        CancellationToken cancellationToken)
    {
        var cities = await countryRepository.GetCitiesByCountryIdAsync(query.CountryId, cancellationToken);
        
        IReadOnlyList<CityResponse> result = cities
            .Select(country => new CityResponse(country.Id, country.Name))
            .ToList();

        return Result.Success(result);
    }
}