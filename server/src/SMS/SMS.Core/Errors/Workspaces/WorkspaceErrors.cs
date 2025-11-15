using SMS.Core.Common;

namespace SMS.Core.Errors.Workspaces;

public static class WorkspaceErrors
{
    public static readonly Error CanNotFindWorkspace = Error.NotFound(
        WorkspaceErrorCode.CanNotFindWorkspace,
        "Can not find workspace");
}
