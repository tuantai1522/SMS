using SMS.Core.Common;
using SMS.Core.Features.Users;

namespace SMS.Core.Features.Teams;

public sealed class TeamMember : IDateTracking, ISoftDelete
{
    public Guid TeamId { get; init; }
    public Team Team { get; init; } = null!;
    
    public Guid UserId { get; init; }
    public User User { get; init; } = null!;

    public TeamMemberRole Role { get; private set; } = TeamMemberRole.Member;

    public long CreatedAt { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public long? UpdatedAt { get; private set; }

    private TeamMember()
    {
    }

    internal static TeamMember CreateTeamMember(Guid teamId, Guid userId)
    {
        return new TeamMember
        {
            TeamId = teamId,
            UserId = userId,
        };
    }

    public long? DeletedAt { get; private set; }

    public void Delete()
    {
        DeletedAt = DeletedAt.HasValue ? null : DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}