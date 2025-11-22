using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed class WorkspaceMember : BaseEntity, IDateTracking, ISoftDelete
{
    public Guid WorkspaceId { get; init; }

    public Guid UserId { get; init; }
    
    public Guid RoleId { get; private set; }
    
    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }
    
    public long? DeletedAt { get; private set; }
    
    private WorkspaceMember() { }

    public static WorkspaceMember Create(Guid workspaceId, Guid userId, Guid roleId)
    {
        return new WorkspaceMember
        {
            WorkspaceId = workspaceId,
            UserId = userId,
            RoleId = roleId,
        };
    }
    
    public void Delete()
    {
        DeletedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
    
    public void UpdateRoleId(Guid roleId)
    {
        RoleId = roleId;
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}