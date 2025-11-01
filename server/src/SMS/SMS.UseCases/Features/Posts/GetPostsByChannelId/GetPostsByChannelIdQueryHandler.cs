using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Posts;
using SMS.Core.Features.Posts;
using SMS.UseCases.Pagination;
using SMS.UseCases.Pagination.CursorPagination;

namespace SMS.UseCases.Features.Posts.GetPostsByChannelId;

internal sealed class GetPostsByChannelIdQueryHandler(IPostRepository postRepository): IRequestHandler<GetPostsByChannelIdQuery, Result<CursorPaginationResponse<GetPostsByChannelIdResponse>>>
{
    public async Task<Result<CursorPaginationResponse<GetPostsByChannelIdResponse>>> Handle(GetPostsByChannelIdQuery query, CancellationToken cancellationToken)
    {
        Guid? lastId = null;
        long? createdAt = null;
        
        if (!string.IsNullOrWhiteSpace(query.Cursor))
        {
            var decodedCursor = Cursor.Decode(query.Cursor);

            if (decodedCursor is null)
            {
                return Result.Failure<CursorPaginationResponse<GetPostsByChannelIdResponse>>(PostErrors.InvalidCursorValue);
            }
            
            lastId = decodedCursor.LastId;
            createdAt = decodedCursor.CreatedAt;
        }
        
        var posts = await postRepository.GetPostsByChannelIdAsync(query.ChannelId, query.RootId, createdAt, lastId, query.Order == PaginationOrder.Ascending, query.PageSize, cancellationToken);
     
        bool hasMore = posts.Count >= query.PageSize;

        var nextCursor = hasMore
            ? Cursor.Encode(posts[^1].CreatedAt, posts[^1].Id)
            : null;

        var beforeCursor = posts.Count > 0
            ? Cursor.Encode(posts[0].CreatedAt, posts[0].Id)
            : null;
        
        var result = posts.Select(p => new GetPostsByChannelIdResponse(p.Id, p.Message, p.RootId, p.UserId, p.CreatedAt, p.UpdatedAt)).ToList();

        var response = new CursorPaginationResponse<GetPostsByChannelIdResponse>
        {
            Items = result,
            NextCursor = nextCursor,
            BeforeCursor = beforeCursor,
            HasMore = hasMore,
            CurrentOrder = query.Order
        };

        return Result.Success(response);
    }
}
