using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Countries.GetCountries;

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

                return Results.Ok(BaseResult<IReadOnlyList<CountryResponse>>.FromResult(result));
        })
        .WithTags(Tags.Countries);
    }
}
