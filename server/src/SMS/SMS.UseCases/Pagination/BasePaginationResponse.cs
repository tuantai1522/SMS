namespace SMS.UseCases.Pagination;

public abstract class BasePaginationResponse<TResponse> where TResponse : class
{
    public IReadOnlyList<TResponse> Items { get; set; } = [];
}