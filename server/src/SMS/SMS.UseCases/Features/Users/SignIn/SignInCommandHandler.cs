using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Users;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Abstractions.WebStorages;

namespace SMS.UseCases.Features.Users.SignIn;

internal sealed class SignInCommandHandler(
    ITokenProvider tokenProvider,
    IUnitOfWork unitOfWork,
    ICookieService cookieService,
    IUserRepository userRepository,
    IPasswordHasher passwordHasher): IRequestHandler<SignInCommand, Result<SignInResponse>>
{
    public async Task<Result<SignInResponse>> Handle(SignInCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindUserByEmailAsync(command.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<SignInResponse>(UserErrors.InvalidPassword);
        }
        
        bool verified = passwordHasher.Verify(command.Password, user.Password);

        if (!verified)
        {
            return Result.Failure<SignInResponse>(UserErrors.InvalidPassword);
        }

        string accessToken = tokenProvider.CreateAccessToken(user);
        
        // To store refresh token in database
        var (refreshToken, expiredAt) = tokenProvider.CreateRefreshToken();
        
        user.AddRefreshToken(refreshToken, expiredAt);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        // Set cookie of refreshToken in browser
        cookieService.Set(Constant.RefreshTokenCookieName, refreshToken, expiredAt);

        return Result.Success(new SignInResponse(accessToken, user.Id, user.Email, user.NickName));
    }
}
