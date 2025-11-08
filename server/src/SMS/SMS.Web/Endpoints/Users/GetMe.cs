using MediatR;
using SMS.UseCases.Features.Users.GetMe;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Users;

internal sealed class GetMe : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/me", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetMeQuery();

            var result = await mediator.Send(query, cancellationToken);
            
            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Users)
        .RequireAuthorization();
    }
}
