using SMS.Core.Common;

namespace SMS.Core.Features.Teams;

public static class TeamErrors
{
    public static readonly Error UserAlreadyExistedInTeam = Error.Conflict(
        "Teams.UserAlreadyExistedInTeam",
        "This user already existed in a team.");
}
