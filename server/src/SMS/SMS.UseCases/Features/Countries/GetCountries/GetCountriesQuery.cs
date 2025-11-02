using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Countries.GetCountries;

public sealed record GetCountriesQuery : IRequest<Result<IReadOnlyList<CountryResponse>>>;