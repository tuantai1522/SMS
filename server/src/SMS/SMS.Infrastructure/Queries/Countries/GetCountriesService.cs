using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Countries;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Features.Countries.GetCountries;
using SMS.UseCases.Queries.Countries;

namespace SMS.Infrastructure.Queries.Countries;

public sealed class GetCountriesService(IApplicationDbContext context) : IGetCountriesService
{
    public async Task<IReadOnlyList<CountryResponse>> Handle(CancellationToken cancellationToken)
    {
        return await context.Set<Country>()
            .Select(country => new CountryResponse(country.Id, country.Name))
            .ToListAsync(cancellationToken);
    }
}