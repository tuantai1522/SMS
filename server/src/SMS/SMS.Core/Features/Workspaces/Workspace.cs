using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed class Workspace : AggregateRoot, IDateTracking
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
        
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
        return new Workspace
        {
            Name = name,
            Description = description,
            OwnerId = ownerId,
            InvitationCode = CreateInvitationToken(),
        };
    }

    private static string CreateInvitationToken() => Guid.NewGuid().ToString();
}