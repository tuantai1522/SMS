using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Channels.GetChannelsByTeamId;

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

            return Results.Ok(BaseResult<GetChannelsByTeamIdQuery>.FromResult(result));
        })
        .WithTags(Tags.Teams)
        .RequireAuthorization();
    }
}
