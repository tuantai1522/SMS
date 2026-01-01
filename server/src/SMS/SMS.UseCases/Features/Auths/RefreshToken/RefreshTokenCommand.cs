using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Auths.RefreshToken;

public sealed record RefreshTokenCommand : IRequest<Result<RefreshTokenResponse>>;
