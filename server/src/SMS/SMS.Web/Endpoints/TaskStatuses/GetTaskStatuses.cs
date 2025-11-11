using MediatR;
using SMS.UseCases.Features.Tasks.GetTaskStatuses;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.TaskStatuses;

internal sealed class GetTaskStatuses : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("task-statuses", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetTaskStatusesQuery();

            var result = await mediator.Send(query, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.TaskStatuses)
        .RequireAuthorization();
    }
}
