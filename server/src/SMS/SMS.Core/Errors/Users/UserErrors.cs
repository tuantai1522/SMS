using SMS.Core.Common;

namespace SMS.Core.Errors.Users;

public static class UserErrors
{
    public static readonly Error EmailNotUnique = Error.Validation(
        UserErrorCode.EmailNotUnique,
        "The provided email is already existed.");

    public static readonly Error InvalidPassword = Error.Validation(
        UserErrorCode.InvalidPassword,
        "Password is not correct. Please try again.");

    public static readonly Error InvalidUserIds = Error.Validation(
        UserErrorCode.InvalidUserIds,
        "List User ids is invalid. Please check again.");
    
    public static readonly Error IdNotFound = Error.NotFound(
        UserErrorCode.IdNotFound,
        "Can not find this user");
}
