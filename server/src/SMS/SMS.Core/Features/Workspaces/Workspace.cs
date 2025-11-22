using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed class Workspace : AggregateRoot, IDateTracking
{
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    
    public Guid OwnerId { get; init; }
    
    public string InvitationCode { get; private set; } = null!;
    
    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }
    
    /// <summary>
    /// List workspace members of this workspace
    /// </summary>
    private readonly List<WorkspaceMember> _workspaceMembers = [];
    
    public IReadOnlyList<WorkspaceMember> WorkspaceMembers => _workspaceMembers.ToList();
    
    private Workspace() { }

    public static Workspace CreateWorkspace(string name, string? description, Guid ownerId)
    {
        var workspace = new Workspace
        {
            Name = name,
            Description = description,
            OwnerId = ownerId,
            InvitationCode = CreateInvitationToken(),
        };
        
        workspace.RaiseDomainEvent(new WorkspaceCreatedDomainEvent(workspace.Id, ownerId));

        return workspace;
    }

    private static string CreateInvitationToken() => Guid.NewGuid().ToString();

    public void Update(string name, string? description)
    {
        Name = name;
        Description = description;
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public void AddMember(Guid userId, Guid roleId)
    {
        var workspaceMember = WorkspaceMember.Create(Id, userId, roleId);
        
        _workspaceMembers.Add(workspaceMember);
    }
}