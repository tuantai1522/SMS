using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Countries.GetCitiesByCountryId;

public sealed record GetCitiesByCountryIdQuery(int CountryId) : IRequest<Result<IReadOnlyList<CityResponse>>>;
