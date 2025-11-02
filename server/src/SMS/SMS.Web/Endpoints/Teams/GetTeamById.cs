using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Teams.GetTeamById;

namespace SMS.Web.Endpoints.Teams;

internal sealed class GetTeamById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("teams/{id:guid}", async (
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetTeamByIdQuery(id);

            var result = await mediator.Send(query, cancellationToken);

            return Results.Ok(BaseResult<GetTeamByIdResponse>.FromResult(result));
        })
        .WithTags(Tags.Teams)
        .RequireAuthorization();
    }
}
