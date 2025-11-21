using SMS.Core.Common;

namespace SMS.Core.Errors.Tasks;

public static class TaskErrors
{
    public static readonly Error CanNotFindProject = Error.NotFound(
        TaskErrorCode.CanNotFindProject,
        "Can not find project");
    
    public static readonly Error CanNotCreateTask = Error.NotFound(
        TaskErrorCode.CanNotCreateTask,
        "Can not create task. Please try again!");
    
    public static readonly Error CanNotFindPriorityById = Error.NotFound(
        TaskErrorCode.CanNotFindPriorityById,
        "Can not find priority by id");
    
    public static readonly Error CanNotFindStatusById = Error.NotFound(
        TaskErrorCode.CanNotFindStatusById,
        "Can not find status by id");
}
