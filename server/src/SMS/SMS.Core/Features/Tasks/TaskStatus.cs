using SMS.Core.Common;

namespace SMS.Core.Features.Tasks;

public sealed class TaskStatus : AggregateRoot
{
    public string Name { get; private set; } = null!;
}