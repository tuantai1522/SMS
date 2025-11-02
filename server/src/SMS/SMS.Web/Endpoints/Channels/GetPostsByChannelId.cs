using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Posts.GetPostsByChannelId;
using SMS.UseCases.Pagination;
using SMS.UseCases.Pagination.CursorPagination;

namespace SMS.Web.Endpoints.Channels;

internal sealed class GetPostsByChannelId : IEndpoint
{
    private sealed record Request(Guid? RootId, string? Cursor, int PageSize, PaginationOrder Order);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("channels/{channelId:guid}/posts", async (
            Guid channelId,
            [AsParameters] Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetPostsByChannelIdQuery(
                channelId,
                request.RootId,
                request.Cursor,
                request.PageSize,
                request.Order
            );

            var result = await mediator.Send(query, cancellationToken);

            return Results.Ok(BaseResult<CursorPaginationResponse<GetPostsByChannelIdResponse>>.FromResult(result));
            
        })
        .WithTags(Tags.Channels)
        .RequireAuthorization();
    }
}
