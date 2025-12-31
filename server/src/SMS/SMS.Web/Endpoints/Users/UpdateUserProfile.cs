using MediatR;
using SMS.Core.Features.Users;
using SMS.UseCases.Features.Users.UpdateUserProfile;
using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web.Endpoints.Users;

internal sealed class UpdateUserProfile : IEndpoint
{
    private sealed record Request(string GivenName, DateOnly DateOfBirth, GenderType GenderType, string? AvatarUrl, int CountryId);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("users/{id:guid}", async (
                Guid id,
                Request request,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = new UpdateUserProfileCommand(id, request.GivenName, request.DateOfBirth, request.GenderType, request.AvatarUrl, request.CountryId);

                var result = await mediator.Send(command, cancellationToken);

                return result.Match(CustomResults.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Users)
            .RequireAuthorization();
    }
}
