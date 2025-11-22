using SMS.Core.Common;

namespace SMS.Core.Features.Tasks;

public sealed class TaskPriority : AggregateRoot
{
    public string Name { get; private set; } = null!;
}