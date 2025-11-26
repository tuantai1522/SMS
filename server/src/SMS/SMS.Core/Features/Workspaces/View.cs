using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed class View : AggregateRoot
{
    public string Name { get; private set; } = null!;
    
    public int Code { get; private set; }
    
    public string? Vid { get; private set; }
    
    public bool IsMenu { get; private set; }
    
    public int Order { get; private set; }
    
    public string? Icon { get; private set; }
    
    public ViewPermission ViewPermission { get; set; } = null!;
        
    /// <summary>
    /// List role permissions of current view
    /// </summary>
    private readonly List<ViewRole> _viewRoles = [];
    
    public IReadOnlyList<ViewRole> ViewRoles => _viewRoles.ToList();
}