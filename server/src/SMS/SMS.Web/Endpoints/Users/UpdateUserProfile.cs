using MediatR;
using SMS.Core.Features.Users;
using SMS.UseCases.Features.Users.UpdateUserProfile;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Users;

internal sealed class UpdateUserProfile : IEndpoint
{
    private sealed record Request(string GivenName, string? AvatarUrl);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("users", async (
                Request request,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = new UpdateUserProfileCommand(request.GivenName, request.AvatarUrl);

                var result = await mediator.Send(command, cancellationToken);

                return result.Match(CustomResults.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Users)
            .RequireAuthorization();
    }
}
