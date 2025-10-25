using SMS.Core.Common;

namespace SMS.Core.Features.Users;

public static class UserErrors
{
    public static readonly Error EmailNotUnique = Error.Conflict(
        "Users.EmailNotUnique",
        "The provided email is not unique");
    
    public static readonly Error NickNameNotUnique = Error.Conflict(
        "Users.EmailNotUnique",
        "The provided nick name is not unique");
    
    public static readonly Error InvalidPassword = Error.NotFound(
        "Users.InvalidPassword",
        "Password is not correct. Please try again.");
}
