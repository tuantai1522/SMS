using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.RefreshTokens.GetAccessToken;

namespace SMS.Web.Endpoints.RefreshTokens;

internal sealed class RefreshToken : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("tokens/refresh-token", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new RefreshTokenCommand();

            var result = await mediator.Send(query, cancellationToken);

            return Results.Ok(BaseResult<RefreshTokenResponse>.FromResult(result));
        })
        .WithTags(Tags.Tokens)
        .RequireAuthorization();
    }
}
