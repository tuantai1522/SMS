using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Users;
using SMS.UseCases.Features.Users.SignUp;

namespace SMS.Web.Endpoints.Users;

internal sealed class SignUp : IEndpoint
{
    private sealed record Request(
        string FirstName,
        string? MiddleName,
        string? LastName,
        string NickName,
        string Email,
        string Password,
        DateOnly DateOfBirth,
        GenderType GenderType,
        string Street,
        int CityId);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users", async (
            Request request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new SignUpCommand(request.FirstName, 
                request.MiddleName, 
                request.LastName, 
                request.NickName, 
                request.Email, 
                request.Password,
                request.DateOfBirth, 
                request.GenderType, 
                request.Street, 
                request.CityId);

            var result = await mediator.Send(command, cancellationToken);

            return Results.Ok(BaseResult<SignUpCommand>.FromResult(result));
        })
        .WithTags(Tags.Users);
    }
}
