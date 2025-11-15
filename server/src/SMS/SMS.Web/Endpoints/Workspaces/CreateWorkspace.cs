using MediatR;
using SMS.UseCases.Features.Workspaces.CreateWorkspace;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Workspaces;

internal sealed class CreateWorkspace : IEndpoint
{
    private sealed record Request(string Name, string? Description);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("workspaces", async (
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateWorkspaceCommand(request.Name, request.Description);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Workspaces)
        .RequireAuthorization();
    }
}
