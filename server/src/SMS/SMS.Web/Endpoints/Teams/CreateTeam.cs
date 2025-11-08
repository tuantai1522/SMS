using MediatR;
using SMS.UseCases.Features.Teams.CreateTeam;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Teams;

internal sealed class CreateTeam : IEndpoint
{
    private sealed record Request(string DisplayName, string? Description, IReadOnlyList<Guid> OwnerIds, IReadOnlyList<Guid> MemberIds);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("teams", async (
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateTeamCommand(request.DisplayName, request.Description, request.OwnerIds, request.MemberIds);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Teams)
        .RequireAuthorization();
    }
}
