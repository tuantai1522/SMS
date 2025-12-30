using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Queries.Countries;

namespace SMS.UseCases.Features.Countries.GetCountries;

public class GetCountriesQueryHandler(IGetCountriesService getCountriesService) : IRequestHandler<GetCountriesQuery, Result<IReadOnlyList<CountryResponse>>>
{
    public async Task<Result<IReadOnlyList<CountryResponse>>> Handle(GetCountriesQuery query, CancellationToken cancellationToken)
    {
        return Result.Success(await getCountriesService.Handle(cancellationToken));
    }
}