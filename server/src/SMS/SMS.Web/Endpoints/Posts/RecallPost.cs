using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Posts.RecallPost;

namespace SMS.Web.Endpoints.Posts;

internal sealed class RecallPost : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("posts/{postId:guid}", async (
            Guid postId,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new RecallPostCommand(postId);

            var result = await mediator.Send(command, cancellationToken);
            
            return Results.Ok(BaseResult<Guid>.FromResult(result));
        })
        .WithTags(Tags.Posts);
    }
}
