using MediatR;
using SMS.UseCases.Features.Auths.GoogleSignIn.GetGoogleAuthenticationUrl;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Auths;

internal sealed class GetGoogleAuthenticationUrl : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("auths/google-url", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetGoogleAuthenticationQuery();

            var result = await mediator.Send(query, cancellationToken);
            
            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Auths);
    }
}
