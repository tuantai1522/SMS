using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Auths.GoogleSignIn;

public sealed record GoogleSignInCommand(string Code) : IRequest<Result<GoogleSignInResponse>>;
