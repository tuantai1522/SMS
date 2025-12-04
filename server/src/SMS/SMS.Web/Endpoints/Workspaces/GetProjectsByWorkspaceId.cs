using MediatR;
using SMS.UseCases.Features.Projects.GetProjectsByWorkspaceId;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Workspaces;

internal sealed class GetProjectsByWorkspaceId : IEndpoint
{
    private sealed record Request(int Page, int PageSize);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("workspaces/projects", async (
                Guid workspaceId,
                [AsParameters] Request request,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var query = new GetProjectsByWorkspaceIdQuery(workspaceId)
                {
                    Page = request.Page,
                    PageSize = request.PageSize
                };

                var result = await mediator.Send(query, cancellationToken);

                return result.Match(CustomResults.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Workspaces)
            .RequireAuthorization();
    }
}
