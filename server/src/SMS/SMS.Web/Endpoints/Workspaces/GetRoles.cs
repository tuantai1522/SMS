using MediatR;
using SMS.UseCases.Features.Workspaces.GetRoles;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Workspaces;

internal sealed class GetRoles : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("roles", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetRolesQuery();

            var result = await mediator.Send(query, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Workspaces)
        .RequireAuthorization();
    }
}
