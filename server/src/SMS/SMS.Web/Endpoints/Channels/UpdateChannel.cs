using MediatR;
using SMS.UseCases.Features.Channels.UpdateChannel;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Channels;

internal sealed class UpdateChannel : IEndpoint
{
    private sealed record Request(string DisplayName, string? Description);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("channels/{id:guid}", async (
            Guid id,
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateChannelCommand(id, request.DisplayName, request.Description);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Channels)
        .RequireAuthorization();
    }
}
