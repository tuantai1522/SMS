using MediatR;
using SMS.UseCases.Features.Channels.CreateChannel;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Channels;

internal sealed class CreateChannel : IEndpoint
{
    private sealed record Request(string DisplayName, string? Description, IReadOnlyList<Guid> OwnerIds, IReadOnlyList<Guid> MemberIds);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("channels/{teamId:guid}", async (
            Guid teamId,
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateChannelCommand(request.DisplayName, request.Description, teamId, request.OwnerIds, request.MemberIds);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Channels)
        .RequireAuthorization();
    }
}
