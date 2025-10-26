using MediatR;
using SMS.UseCases.Features.Teams.GetTeams;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Teams;

internal sealed class GetTeams : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("teams", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetTeamsQuery();

            var result = await mediator.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Teams)
        .RequireAuthorization();
    }
}
