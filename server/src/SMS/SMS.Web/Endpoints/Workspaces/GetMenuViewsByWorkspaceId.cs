using MediatR;
using SMS.UseCases.Features.Workspaces.GetMenuViewsByWorkspaceId;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Workspaces;

internal sealed class GetMenuViewsByWorkspaceId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("workspaces/views", async (
                Guid workspaceId,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var query = new GetMenuViewsByWorkspaceIdQuery(workspaceId);

                var result = await mediator.Send(query, cancellationToken);

                return result.Match(CustomResults.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Workspaces)
            .RequireAuthorization();
    }
}
