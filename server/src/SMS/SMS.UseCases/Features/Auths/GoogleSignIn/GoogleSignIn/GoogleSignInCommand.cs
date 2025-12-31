using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Users.SignIn;

namespace SMS.UseCases.Features.Auths.GoogleSignIn.GoogleSignIn;

public sealed record GoogleSignInCommand(string Code) : IRequest<Result<GoogleSignInResponse>>;
