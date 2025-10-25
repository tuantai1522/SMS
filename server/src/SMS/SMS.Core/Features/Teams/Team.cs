using SMS.Core.Common;

namespace SMS.Core.Features.Teams;

public sealed class Team : AggregateRoot, IDateTracking, ISoftDelete
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    public string DisplayName { get; private set; } = null!;
    public string? Description { get; private set; }

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }
    
    
    private readonly List<TeamMember> _teamMembers = [];
    
    public IReadOnlyList<TeamMember> TeamMembers => _teamMembers.ToList();
    
    private Team() { }

    public static Team CreateTeam(string displayName, string? description, IReadOnlyList<Guid> ownerIds, IReadOnlyList<Guid> memberIds)
    {
        var team = new Team
        {
            DisplayName = displayName,
            Description = description,
        };

        // Add owners
        foreach (var ownerId in ownerIds)
        {
            team.AddTeamMember(ownerId, TeamMemberRole.Owner);
        }

        // Add members
        foreach (var memberId in memberIds)
        {
            team.AddTeamMember(memberId, TeamMemberRole.Member);
        }

        return team;
    }

    public Result AddTeamMember(Guid userId, TeamMemberRole role)
    {
        if (_teamMembers.Any(teamMember => teamMember.UserId == userId))
        {
            return Result.Failure(TeamErrors.UserAlreadyExistedInTeam);
        }
        
        _teamMembers.Add(TeamMember.CreateTeamMember(Id, userId, role));
        
        return Result.Success();
    }

    public long? DeletedAt { get; private set; }
    
    public void Delete()
    {
        DeletedAt = DeletedAt.HasValue ? null : DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
    
    public void Update(string displayName, string? description)
    {
        DisplayName = displayName;
        Description = description;
        
        // Todo: To bring into interceptors
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}