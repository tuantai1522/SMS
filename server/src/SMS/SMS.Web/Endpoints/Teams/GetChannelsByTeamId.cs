using MediatR;
using SMS.UseCases.Features.Channels.GetChannelsByTeamId;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Teams;

internal sealed class GetChannelsByTeamId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("teams/{teamId:guid}/channels", async (
            Guid teamId,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetChannelsByTeamIdQuery(teamId);

            var result = await mediator.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Teams)
        .RequireAuthorization();
    }
}
