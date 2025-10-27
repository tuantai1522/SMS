using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Pagination.CursorPagination;

public class CursorPaginationRequest<TResponse> : BasePaginationRequest, IRequest<Result<CursorPaginationResponse<TResponse>>> where TResponse : class
{
    public long CreatedAt { get; set; }
    
    public Guid LastId { get; set; }
    
    public PaginationOrder Order { get; set; }
}