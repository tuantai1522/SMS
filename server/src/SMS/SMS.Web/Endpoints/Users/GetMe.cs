using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Users.GetMe;

namespace SMS.Web.Endpoints.Users;

internal sealed class GetMe : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/me", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new GetMeQuery();

            var result = await mediator.Send(command, cancellationToken);
            
            return Results.Ok(BaseResult<GetMeResponse>.FromResult(result));
        })
        .WithTags(Tags.Users)
        .RequireAuthorization();
    }
}
