using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.UseCases.Features.Projects.GetProjectByIdAndWorkspaceId;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Projects;

internal sealed class GetProjectByIdAndWorkspaceId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("projects/{id:guid}", async (
                Guid id,
                [FromQuery] Guid workspaceId,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var query = new GetProjectByIdAndWorkspaceIdQuery(id, workspaceId);

                var result = await mediator.Send(query, cancellationToken);

                return result.Match(CustomResults.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Projects)
            .RequireAuthorization();
    }
}
