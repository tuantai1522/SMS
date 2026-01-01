using MediatR;
using SMS.UseCases.Features.Auths.SignIn;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Auths;

internal sealed class SignIn : IEndpoint
{
    private sealed record Request(string Email, string Password);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auths/sign-in", async (
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new SignInCommand(request.Email, request.Password);

            var result = await mediator.Send(command, cancellationToken);
            
            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Auths);
    }
}
