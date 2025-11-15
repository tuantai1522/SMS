using SMS.Core.Common;

namespace SMS.Core.Errors.Roles;

public static class RoleErrors
{
    public static readonly Error CanNotFindRole = Error.Validation(
        RoleErrorCode.CanNotFindRole,
        "Can't not find role");
}
