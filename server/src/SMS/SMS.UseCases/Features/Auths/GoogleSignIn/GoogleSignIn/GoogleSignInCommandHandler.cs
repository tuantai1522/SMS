using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Authentications;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Abstractions.WebStorages;
using SMS.UseCases.Interfaces;

namespace SMS.UseCases.Features.Auths.GoogleSignIn.GoogleSignIn;

internal sealed class GoogleSignInCommandHandler(
    IGoogleAuthentication googleAuthentication,
    IUnitOfWork unitOfWork,
    ICookieService cookieService,
    IUserRepository userRepository,
    ITokenProvider tokenProvider) : IRequestHandler<GoogleSignInCommand, Result<GoogleSignInResponse>>
{
    public async Task<Result<GoogleSignInResponse>> Handle(GoogleSignInCommand command, CancellationToken cancellationToken)
    {
        // Step 1: send code to get google user info
        var googleUser = await googleAuthentication.GetGoogleUserAsync(command.Code);

        if (googleUser == null)
        {
            return Result.Failure<GoogleSignInResponse>(AuthenticationErrors.GoogleSignInError);
        }

        var user = await userRepository.FindUserByEmailAsync(googleUser.Email, cancellationToken);

        // Step 2: To check if user exists
        if (user == null)
        {
            var newUser = User.CreateUser(googleUser.Email, string.Empty, UserStatus.OnboardingRequired, null, null);
            await userRepository.AddUserAsync(newUser, cancellationToken);
            
            newUser.AddUserSignIns(ProviderType.Facebook, googleUser.Id, googleUser.Email);

            string accessToken = tokenProvider.CreateAccessToken(newUser);

            // To store refresh token in database
            var (refreshToken, expiredAt) = tokenProvider.CreateRefreshToken();

            newUser.AddRefreshToken(refreshToken, expiredAt);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            // Set cookie of refreshToken in browser
            cookieService.Set(Constant.RefreshTokenCookieName, refreshToken, expiredAt);

            return Result.Success(new GoogleSignInResponse(accessToken, newUser.Id, newUser.Email, newUser.Status));
        }
        else
        {
            var accessToken = tokenProvider.CreateAccessToken(user);

            // To store refresh token in database
            var (refreshToken, expiredAt) = tokenProvider.CreateRefreshToken();

            user.AddRefreshToken(refreshToken, expiredAt);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            // Set cookie of refreshToken in browser
            cookieService.Set(Constant.RefreshTokenCookieName, refreshToken, expiredAt);

            return Result.Success(new GoogleSignInResponse(accessToken, user.Id, user.Email, user.Status));
        }
    }
}
