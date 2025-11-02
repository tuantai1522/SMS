using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Users.SignOut;

namespace SMS.Web.Endpoints.Users;

internal sealed class SignOut : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/sign-out", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new SignOutCommand();

            var result = await mediator.Send(command, cancellationToken);
            
            return Results.Ok(BaseResult<bool>.FromResult(result));
        })
        .WithTags(Tags.Users)
        .RequireAuthorization();
    }
}
