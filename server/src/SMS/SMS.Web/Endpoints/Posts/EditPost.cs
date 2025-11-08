using MediatR;
using SMS.UseCases.Features.Posts.EditPost;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Posts;

internal sealed class EditPost : IEndpoint
{
    private sealed record Request(string Message);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("posts/{postId:guid}", async (
            Guid postId,
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new EditPostCommand(postId, request.Message);

            var result = await mediator.Send(command, cancellationToken);
            
            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Posts)
        .RequireAuthorization();
    }
}
