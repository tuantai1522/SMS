using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Teams.GetTeams;

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

            return Results.Ok(BaseResult<IReadOnlyList<GetTeamsResponse>>.FromResult(result));
        })
        .WithTags(Tags.Teams)
        .RequireAuthorization();
    }
}
