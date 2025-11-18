using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.UseCases.Features.Projects.GetProjectById;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Projects;

internal sealed class GetProjectById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("projects/{id:guid}", async (
                Guid id,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var query = new GetProjectByIdQuery(id);

                var result = await mediator.Send(query, cancellationToken);

                return result.Match(CustomResults.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Projects)
            .RequireAuthorization();
    }
}
