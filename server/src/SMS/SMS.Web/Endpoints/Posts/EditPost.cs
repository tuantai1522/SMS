using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Posts.EditPost;

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
            
            return Results.Ok(BaseResult<Guid>.FromResult(result));
        })
        .WithTags(Tags.Posts)
        .RequireAuthorization();
    }
}
