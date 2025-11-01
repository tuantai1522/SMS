using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Channels.CreateChannel;

namespace SMS.Web.Endpoints.Teams;

internal sealed class CreateChannel : IEndpoint
{
    private sealed record Request(string DisplayName, string? Description, IReadOnlyList<Guid> OwnerIds, IReadOnlyList<Guid> MemberIds);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("teams/{teamId:guid}/channels", async (
            Guid teamId,
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateChannelCommand(request.DisplayName, request.Description, teamId, request.OwnerIds, request.MemberIds);

            var result = await mediator.Send(command, cancellationToken);

            return Results.Ok(BaseResult<CreateChannelCommand>.FromResult(result));
        })
        .WithTags(Tags.Teams)
        .RequireAuthorization();
    }
}
