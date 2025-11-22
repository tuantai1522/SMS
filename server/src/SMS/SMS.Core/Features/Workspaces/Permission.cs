using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed class Permission : AggregateRoot
{
    public string Name { get; private set; } = null!;
}