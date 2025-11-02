using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.RefreshTokens.GetAccessToken;

public sealed record RefreshTokenCommand : IRequest<Result<RefreshTokenResponse>>;
