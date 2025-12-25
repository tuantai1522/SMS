using SMS.Core.Common;

namespace SMS.Core.Errors.Authentications;

public static class AuthenticationErrors
{
    public static readonly Error UnAuthorized = Error.Authentication(
        AuthenticationErrorCode.UnAuthorized,
        "Unauthorized access");

    public static readonly Error UnAuthenticated = Error.Authentication(
        AuthenticationErrorCode.UnAuthenticated,
        "Unauthenticated access");
}
