using MediatR;
using SMS.UseCases.Features.Posts.CreatePost;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Channels;

internal sealed class CreatePost : IEndpoint
{
    private sealed record Request(Guid? RootId, string Message);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("channels/{channelId:guid}/posts", async (
            Guid channelId,
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new CreatePostCommand(channelId, request.RootId, request.Message);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Channels)
        .RequireAuthorization();
    }
}
