using MediatR;
using SMS.UseCases.Features.Projects.CreateProject;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Projects;

internal sealed class CreateProject : IEndpoint
{
    private sealed record Request(string Name, string Code, string? Emoji, string? Description, Guid WorkspaceId);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("projects", async (
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateProjectCommand(request.Name, request.Code, request.Emoji, request.Description, request.WorkspaceId);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Projects)
        .RequireAuthorization();
    }
}
