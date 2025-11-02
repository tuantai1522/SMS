using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Teams.CreateTeam;

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

            return Results.Ok(BaseResult<Guid>.FromResult(result));
        })
        .WithTags(Tags.Teams)
        .RequireAuthorization();
    }
}
