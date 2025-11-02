using SMS.Core.Common;

namespace SMS.Core.Errors.Users;

public static class UserErrors
{
    public static readonly Error EmailNotUnique = new(
        UserErrorCode.EmailNotUnique,
        "The provided email is already existed.");

    public static readonly Error NickNameNotUnique = new(
        UserErrorCode.NickNameNotUnique,
        "The provided nick name is not unique");

    public static readonly Error InvalidPassword = new(
        UserErrorCode.InvalidPassword,
        "Password is not correct. Please try again.");

    public static readonly Error InvalidUserIds = new(
        UserErrorCode.InvalidUserIds,
        "List User ids is invalid. Please check again.");
    
    public static readonly Error IdNotFound = new(
        UserErrorCode.IdNotFound,
        "Can not find this user");
}
