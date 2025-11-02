using SMS.Core.Features.Users;

namespace SMS.UseCases.Abstractions.Authentication;

/// <summary>
/// To create Jwt token and refresh token for user.
/// </summary>
public interface ITokenProvider
{
    string CreateAccessToken(User user);
    (string token, long expiredAt) CreateRefreshToken();
}