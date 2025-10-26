using MediatR;
using SMS.UseCases.Features.Users.SignIn;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Users;

internal sealed class SignIn : IEndpoint
{
    private sealed record Request(string Email, string Password);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/sign-in", async (
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new SignInCommand(request.Email, request.Password);

            var result = await mediator.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Users);
    }
}
