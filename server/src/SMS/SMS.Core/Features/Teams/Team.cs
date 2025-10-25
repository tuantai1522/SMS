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

    public static Team CreateTeam(string displayName, string? description, IReadOnlyList<Guid> userIds)
    {
        var team = new Team
        {
            DisplayName = displayName,
            Description = description,
        };

        _ = userIds.Select(userId => TeamMember.CreateTeamMember(team.Id, userId)).ToList();
        
        return team;
    }

    public Result AddTeamMember(Guid userId)
    {
        if (_teamMembers.Any(teamMember => teamMember.UserId == userId))
        {
            return Result.Failure(TeamErrors.UserAlreadyExistedInTeam);
        }
        
        _teamMembers.Add(TeamMember.CreateTeamMember(Id, userId));
        
        return Result.Success();
    }

    public long? DeletedAt { get; private set; }
    
    public void Delete()
    {
        DeletedAt = DeletedAt.HasValue ? null : DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}