using MediatR;
using SMS.UseCases.Features.Tasks.GetTaskPriorities;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.TaskPriorities;

internal sealed class GetTaskPriorities : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("task-priorities", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetTaskPrioritiesQuery();

            var result = await mediator.Send(query, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.TaskPriorities)
        .RequireAuthorization();
    }
}
