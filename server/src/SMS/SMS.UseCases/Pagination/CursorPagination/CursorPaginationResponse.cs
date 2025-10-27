namespace SMS.UseCases.Pagination.CursorPagination;

public sealed class CursorPaginationResponse<TResponse> : BasePaginationResponse<TResponse> where TResponse : class
{
    public string? Cursor { get; set; }
    
    public bool HasMore { get; set; }
}