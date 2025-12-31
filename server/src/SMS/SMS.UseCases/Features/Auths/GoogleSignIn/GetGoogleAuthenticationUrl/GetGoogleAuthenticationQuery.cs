using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Auths.GoogleSignIn.GetGoogleAuthenticationUrl;

public sealed record GetGoogleAuthenticationQuery : IRequest<Result<GetGoogleAuthenticationResponse>>;
