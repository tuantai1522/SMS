using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Posts.CreatePost;

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

            return Results.Ok(BaseResult<Guid>.FromResult(result));
        })
        .WithTags(Tags.Channels)
        .RequireAuthorization();
    }
}
