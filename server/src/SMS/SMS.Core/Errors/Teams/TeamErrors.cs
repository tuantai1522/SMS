using SMS.Core.Common;

namespace SMS.Core.Errors.Teams;

public static class TeamErrors
{
    public static readonly Error CanNotFindTeam = new(
        TeamErrorCode.CanNotFindTeam,
        "Can not find team");
    
    public static readonly Error UserAlreadyExistedInTeam = new(
        TeamErrorCode.UserAlreadyExistedInTeam,
        "This user already existed in a team.");
}
