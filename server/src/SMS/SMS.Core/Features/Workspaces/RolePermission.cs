using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed class RolePermission : BaseEntity
{
    public Guid RoleId { get; private set; }

    public Guid PermissionId { get; private set; }
}