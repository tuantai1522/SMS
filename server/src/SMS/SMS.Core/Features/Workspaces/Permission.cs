using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed class Permission : AggregateRoot
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
        
    public string Name { get; private set; } = null!;
}