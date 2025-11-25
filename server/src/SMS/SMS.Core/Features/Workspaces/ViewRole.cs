using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed class ViewRole : BaseEntity
{
    public Guid RoleId { get; private set; }

    public Guid ViewId { get; private set; }
    
    public ViewPermission ViewPermission { get; set; } = null!;
}