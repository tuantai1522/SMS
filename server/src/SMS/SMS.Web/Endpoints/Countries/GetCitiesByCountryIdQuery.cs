using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Countries.GetCitiesByCountryId;

namespace SMS.Web.Endpoints.Countries;

internal sealed class GetCitiesByCountryId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("countries/{countryId:int}/cities", async (
            int countryId,
            IMediator mediator,
            CancellationToken cancellationToken) =>
            {
                var query = new GetCitiesByCountryIdQuery(countryId);

                var result = await mediator.Send(query, cancellationToken);

                return Results.Ok(BaseResult<IReadOnlyList<CityResponse>>.FromResult(result));
        })
        .WithTags(Tags.Countries);
    }
}
