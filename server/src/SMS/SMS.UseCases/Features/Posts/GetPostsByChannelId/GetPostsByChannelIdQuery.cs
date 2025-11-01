using SMS.UseCases.Pagination;
using SMS.UseCases.Pagination.CursorPagination;

namespace SMS.UseCases.Features.Posts.GetPostsByChannelId;

public sealed class GetPostsByChannelIdQuery : CursorPaginationRequest<GetPostsByChannelIdResponse>
{
    public Guid ChannelId { get; set; }
    public Guid? RootId { get; set; }

    public GetPostsByChannelIdQuery(Guid channelId, Guid? rootId, string? cursor, int pageSize, PaginationOrder order)
    {
        ChannelId = channelId;
        RootId = rootId;
        Cursor = cursor;
        PageSize = pageSize;
        Order = order;
    }
}
