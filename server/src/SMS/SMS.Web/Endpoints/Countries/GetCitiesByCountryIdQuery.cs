using MediatR;
using SMS.UseCases.Features.Countries.GetCitiesByCountryId;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

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

                return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Countries);
    }
}
