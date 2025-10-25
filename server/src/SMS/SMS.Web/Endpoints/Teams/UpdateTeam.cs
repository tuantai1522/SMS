using MediatR;
using SMS.UseCases.Features.Teams.UpdateTeam;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Teams;

internal sealed class UpdateTeam : IEndpoint
{
    private sealed record Request(string DisplayName, string? Description);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("teams/{id:guid}", async (
            Guid id,
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateTeamCommand(id, request.DisplayName, request.Description);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Teams)
        .RequireAuthorization();
    }
}
