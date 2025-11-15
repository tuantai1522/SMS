using MediatR;
using SMS.UseCases.Features.Workspaces.UpdateMemberRole;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Workspaces;

internal sealed class UpdateMemberRole : IEndpoint
{
    private sealed record Request(Guid WorkspaceId, Guid RoleId);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("workspace-members/{userId:guid}", async (
            Guid userId,
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateMemberRoleCommand(userId, request.WorkspaceId, request.RoleId);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Workspaces)
        .RequireAuthorization();
    }
}
