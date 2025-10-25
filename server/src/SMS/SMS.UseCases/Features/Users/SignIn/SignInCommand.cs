using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Users.SignIn;

public sealed record SignInCommand(
    string Email, 
    string Password) : IRequest<Result<SignInResponse>>;
