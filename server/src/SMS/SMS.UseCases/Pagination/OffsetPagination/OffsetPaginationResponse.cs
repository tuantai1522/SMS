using Microsoft.EntityFrameworkCore;

namespace SMS.UseCases.Pagination.OffsetPagination;

public sealed class OffsetPaginationResponse<TResponse> : BasePaginationResponse<TResponse> where TResponse : class
{
    private OffsetPaginationResponse(IReadOnlyList<TResponse> items, int page, int pageSize, int totalCount)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    public bool HasNextPage => Page * PageSize < TotalCount;

    public bool HasPreviousPage => Page > 1;

    public static async Task<OffsetPaginationResponse<TResponse>> CreateAsync(IQueryable<TResponse> query, int page, int pageSize, CancellationToken cancellationToken)
    {
        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

        return new OffsetPaginationResponse<TResponse>(items, page, pageSize, totalCount);
    }
}