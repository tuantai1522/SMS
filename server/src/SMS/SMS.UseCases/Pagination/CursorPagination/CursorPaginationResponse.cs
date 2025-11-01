namespace SMS.UseCases.Pagination.CursorPagination;

public class CursorPaginationResponse<TResponse> : BasePaginationResponse<TResponse> where TResponse : class
{
    public string? NextCursor { get; set; }
    public string? BeforeCursor { get; set; }
    
    public bool HasMore { get; set; }
    
    public PaginationOrder CurrentOrder { get; set; }
}