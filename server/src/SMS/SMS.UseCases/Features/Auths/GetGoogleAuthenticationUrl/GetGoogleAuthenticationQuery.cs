using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Auths.GetGoogleAuthenticationUrl;

public sealed record GetGoogleAuthenticationQuery : IRequest<Result<GetGoogleAuthenticationResponse>>;
