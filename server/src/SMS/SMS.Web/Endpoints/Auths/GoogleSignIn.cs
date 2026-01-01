using MediatR;
using SMS.UseCases.Features.Auths.GoogleSignIn;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Auths;

internal sealed class GoogleSignIn : IEndpoint
{
    private sealed record Request(string Code);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auths/google-sign-in", async (
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new GoogleSignInCommand(request.Code);

            var result = await mediator.Send(command, cancellationToken);
            
            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Auths);
    }
}
