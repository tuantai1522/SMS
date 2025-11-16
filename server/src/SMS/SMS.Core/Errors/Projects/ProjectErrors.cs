using SMS.Core.Common;

namespace SMS.Core.Errors.Projects;

public static class ProjectErrors
{
    public static readonly Error CanNotFindProject = Error.NotFound(
        ProjectErrorCode.CanNotFindProject,
        "Can not find project");
}
