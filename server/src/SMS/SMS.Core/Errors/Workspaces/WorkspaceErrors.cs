using SMS.Core.Common;

namespace SMS.Core.Errors.Workspaces;

public static class WorkspaceErrors
{
    public static readonly Error CanNotFindWorkspace = Error.NotFound(
        WorkspaceErrorCode.CanNotFindWorkspace,
        "Can not find workspace");
    
    public static readonly Error MemberNotFoundInWorkspace = Error.NotFound(
        WorkspaceErrorCode.MemberNotFoundInWorkspace,
        "Member not found in workspace");
}
