using MediatR;
using SMS.UseCases.Features.RefreshTokens.GetAccessToken;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.RefreshTokens;

internal sealed class RefreshToken : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("tokens/refresh-token", async (
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = new RefreshTokenCommand();

                var result = await mediator.Send(command, cancellationToken);

                return result.Match(CustomResults.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Tokens);
    }
}
