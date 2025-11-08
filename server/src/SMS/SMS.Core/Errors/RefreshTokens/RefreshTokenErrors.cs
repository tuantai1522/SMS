using SMS.Core.Common;

namespace SMS.Core.Errors.RefreshTokens;

public static class RefreshTokenErrors
{
    public static readonly Error InvalidRefreshToken = Error.Validation(
        RefreshTokenErrorCode.InvalidRefreshToken,
        "This refresh token is invalid. Please try again!");
}
