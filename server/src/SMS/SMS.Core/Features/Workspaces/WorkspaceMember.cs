using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed class WorkspaceMember : IDateTracking, ISoftDelete
{
    public Guid WorkspaceId { get; init; }

    public Guid UserId { get; init; }
    
    public Guid RoleId { get; init; }
    
    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }
    
    public long? DeletedAt { get; private set; }
    
    private WorkspaceMember() { }
    
    public void Delete()
    {
        DeletedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}