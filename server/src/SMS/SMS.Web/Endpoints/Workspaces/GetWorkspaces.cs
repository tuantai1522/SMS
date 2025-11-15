using MediatR;
using SMS.UseCases.Features.Workspaces.GetWorkspaces;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Workspaces;

internal sealed class GetWorkspaces : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("workspaces", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetWorkspacesQuery();

            var result = await mediator.Send(query, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Workspaces)
        .RequireAuthorization();
    }
}
