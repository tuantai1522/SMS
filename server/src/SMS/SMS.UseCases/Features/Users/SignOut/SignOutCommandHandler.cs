using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.RefreshTokens;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.WebStorages;

namespace SMS.UseCases.Features.Users.SignOut;

internal sealed class SignOutCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IRefreshTokenRepository refreshTokenRepository,
    ICookieService cookieService): IRequestHandler<SignOutCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(SignOutCommand command, CancellationToken cancellationToken)
    {
        var refreshToken = cookieService.Get(Constant.RefreshTokenCookieName);
        
        cookieService.Delete(Constant.RefreshTokenCookieName);
        
        // Update empty token in database
        var token = await refreshTokenRepository.GetRefreshTokenByToken(refreshToken, cancellationToken);

        if (token is not null)
        {
            var user = await userRepository.FindUserByIdAsync(token.UserId, cancellationToken);

            // Todo: To add job to clear empty token
            user?.UpdateRefreshToken(token.Id, string.Empty, token.ExpiredAt);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return Result.Success(true);
    }
}
