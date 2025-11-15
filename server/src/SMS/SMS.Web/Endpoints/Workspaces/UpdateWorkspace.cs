using MediatR;
using SMS.UseCases.Features.Workspaces.UpdateWorkspace;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Workspaces;

internal sealed class UpdateWorkspace : IEndpoint
{
    private sealed record Request(string Name, string? Description);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("workspaces/{id:guid}", async (
            Guid id,
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateWorkspaceCommand(id, request.Name, request.Description);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Workspaces)
        .RequireAuthorization();
    }
}
