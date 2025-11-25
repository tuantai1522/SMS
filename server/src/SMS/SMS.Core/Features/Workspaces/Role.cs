using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed class Role : AggregateRoot
{
    public string Name { get; private set; } = null!;
    
    /// <summary>
    /// List role permissions of current role
    /// </summary>
    private readonly List<ViewRole> _viewRoles = [];
    
    public IReadOnlyList<ViewRole> ViewRoles => _viewRoles.ToList();
}