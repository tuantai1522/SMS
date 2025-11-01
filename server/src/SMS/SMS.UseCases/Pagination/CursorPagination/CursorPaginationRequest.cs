using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Pagination.CursorPagination;

public class CursorPaginationRequest<TResponse> : BasePaginationRequest, IRequest<Result<CursorPaginationResponse<TResponse>>> where TResponse : class
{
    public PaginationOrder Order { get; set; }
    
    public string? Cursor { get; set; }
}