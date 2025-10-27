using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Pagination.OffsetPagination;

public class OffsetPaginationRequest<TResponse> : BasePaginationRequest, IRequest<Result<OffsetPaginationResponse<TResponse>>> where TResponse : class
{
    public int Page {get; set;}
}