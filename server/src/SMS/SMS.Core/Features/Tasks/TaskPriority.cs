using SMS.Core.Common;

namespace SMS.Core.Features.Tasks;

public sealed class TaskPriority : AggregateRoot
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
        
    public string Name { get; private set; } = null!;
}