using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.RefreshTokens;
using SMS.Core.Features.RefreshTokens;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Abstractions.WebStorages;

namespace SMS.UseCases.Features.RefreshTokens.GetAccessToken;

internal sealed class RefreshTokenCommandHandler(
    IUnitOfWork unitOfWork,
    IRefreshTokenRepository refreshTokenRepository,
    ICookieService cookieService,
    IUserRepository userRepository, 
    ITokenProvider tokenProvider): IRequestHandler<RefreshTokenCommand, Result<RefreshTokenResponse>>
{
    public async Task<Result<RefreshTokenResponse>> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var refreshToken = cookieService.Get(Constant.RefreshTokenCookieName);

        var token = await refreshTokenRepository.GetRefreshTokenByToken(refreshToken, cancellationToken);

        if (token is null || token.ExpiredAt < DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
        {
            return Result.Failure<RefreshTokenResponse>(RefreshTokenErrors.InvalidRefreshToken);
        }

        var user = await userRepository.FindUserByIdAsync(token.UserId, cancellationToken);
        if (user is null)
        {
            return Result.Failure<RefreshTokenResponse>(RefreshTokenErrors.InvalidRefreshToken);
        }
        
        string accessToken = tokenProvider.CreateAccessToken(user);
        
        var (newRefreshToken, expiredAt) = tokenProvider.CreateRefreshToken();
        
        // Update new token and expiredAt
        user.UpdateRefreshToken(token.Id, newRefreshToken, expiredAt);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        // Set cookie of refreshToken in browser
        cookieService.Set(Constant.RefreshTokenCookieName, newRefreshToken, expiredAt);
        
        return Result.Success(new RefreshTokenResponse(accessToken));
    }
}
