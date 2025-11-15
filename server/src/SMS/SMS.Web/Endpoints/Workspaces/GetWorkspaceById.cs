using MediatR;
using SMS.UseCases.Features.Workspaces.GetWorkspaceById;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Workspaces;

internal sealed class GetWorkspaceById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("workspaces/{id:guid}", async (
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetWorkspaceByIdQuery(id);

            var result = await mediator.Send(query, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Workspaces)
        .RequireAuthorization();
    }
}
