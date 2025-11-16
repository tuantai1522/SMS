using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.UseCases.Features.Projects.UpdateProject;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Projects;

internal sealed class UpdateProject : IEndpoint
{
    private sealed record Request(string Name, string Code, string? Emoji, string? Description);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("projects/{id:guid}", async (
                Guid id,
                [FromQuery] Guid workspaceId,
                Request request,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = new UpdateProjectCommand(id, request.Name, request.Code, request.Emoji, request.Description, workspaceId);

                var result = await mediator.Send(command, cancellationToken);

                return result.Match(CustomResults.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Projects)
            .RequireAuthorization();
    }
}
