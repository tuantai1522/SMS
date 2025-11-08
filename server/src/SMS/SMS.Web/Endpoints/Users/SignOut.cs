using MediatR;
using SMS.UseCases.Features.Users.SignOut;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

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
            
            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Users)
        .RequireAuthorization();
    }
}
