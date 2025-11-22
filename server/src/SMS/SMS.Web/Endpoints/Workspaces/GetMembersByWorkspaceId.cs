using MediatR;
using SMS.UseCases.Features.Workspaces.GetMembersByWorkspaceId;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Workspaces;

internal sealed class GetMembersByWorkspaceId : IEndpoint
{
    private sealed record Request(int Page, int PageSize);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("workspaces/members", async (
                Guid workspaceId,
                [AsParameters] Request request,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var query = new GetMembersByWorkspaceIdQuery(workspaceId)
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
