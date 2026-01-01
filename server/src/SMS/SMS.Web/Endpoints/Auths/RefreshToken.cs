using MediatR;
using SMS.UseCases.Features.Auths.RefreshToken;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Auths;

internal sealed class RefreshToken : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("auths/refresh-token", async (
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = new RefreshTokenCommand();

                var result = await mediator.Send(command, cancellationToken);

                return result.Match(CustomResults.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Auths);
    }
}
