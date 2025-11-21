namespace SMS.Core.Errors.Tasks;

public static class TaskErrorCode
{
    public const int NameEmpty = -15000;
    public const int ProjectIdEmpty = -15001;
    public const int StatusIdEmpty = -15002;
    public const int PriorityIdEmpty = -15003;
    public const int CanNotFindProject = -15004;
    public const int CanNotCreateTask = -15005;
    public const int CanNotFindStatusById = -15006;
    public const int CanNotFindPriorityById = -15007;
}
