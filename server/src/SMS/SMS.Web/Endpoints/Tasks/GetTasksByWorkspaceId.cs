using MediatR;
using SMS.UseCases.Features.Tasks.GetTasksByWorkspaceId;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Tasks;

internal sealed class GetTasksByWorkspaceId : IEndpoint
{
    // private sealed class Request
    // {
    //     public Guid? ProjectId { get; set; }
    //     public Guid[]? StatusIds { get; set; } = [];
    //     public Guid[]? PriorityIds { get; set; } = [];
    //     public Guid[]? AssignedToIds { get; set; } = [];
    //     public string? KeyWord { get; set; }
    //     public long? DueDate { get; set; }
    //     public int Page { get; set; } = 1;
    //     public int PageSize { get; set; } = 20;
    //     public bool IsAscending { get; set; }
    // }

    private sealed record Request(
        Guid? ProjectId,
        Guid[]? StatusIds,
        Guid[]? PriorityIds,
        Guid[]? AssignedToIds,
        string? KeyWord,
        long? DueDate,
        int Page,
        int PageSize,
        bool IsAscending);
        
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("tasks", async (
            Guid workspaceId,
            [AsParameters] Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
            {
                var query = new GetTasksByWorkspaceIdQuery(workspaceId, request.ProjectId, request.StatusIds,
                    request.PriorityIds, request.AssignedToIds,
                    request.KeyWord, request.DueDate, request.IsAscending)
                {
                    Page = request.Page,
                    PageSize = request.PageSize,
                };
        
            var result = await mediator.Send(query, cancellationToken);
        
            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Tasks)
        .RequireAuthorization();
    }
}
