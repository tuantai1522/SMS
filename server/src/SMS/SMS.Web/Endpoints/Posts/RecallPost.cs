using MediatR;
using SMS.UseCases.Features.Posts.RecallPost;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

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
            
            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Posts)
        .RequireAuthorization();
    }
}
