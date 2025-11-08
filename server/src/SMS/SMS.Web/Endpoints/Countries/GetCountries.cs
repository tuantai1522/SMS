using MediatR;
using SMS.UseCases.Features.Countries.GetCountries;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Countries;

internal sealed class GetCountries : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("countries", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
            {
                var query = new GetCountriesQuery();

                var result = await mediator.Send(query, cancellationToken);

                return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Countries);
    }
}
