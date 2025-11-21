using MediatR;
using SMS.UseCases.Features.Tasks.CreateTask;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Tasks;

internal sealed class CreateTask : IEndpoint
{
    private sealed record Request(string Name, string? Description, Guid ProjectId, Guid StatusId, Guid PriorityId, Guid? AssignedTo, long? StartDate, long? DueDate);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("tasks", async (
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateTaskCommand(request.Name, request.Description, request.ProjectId, request.StatusId, request.PriorityId, request.AssignedTo, request.StartDate, request.DueDate);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Tasks)
        .RequireAuthorization();
    }
}
