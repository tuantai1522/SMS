namespace SMS.Core.Features.Workspaces;

public sealed class RolePermission
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    public Guid RoleId { get; private set; }

    public Guid PermissionId { get; private set; }
}