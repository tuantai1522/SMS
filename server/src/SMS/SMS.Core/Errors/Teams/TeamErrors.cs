using SMS.Core.Common;

namespace SMS.Core.Errors.Teams;

public static class TeamErrors
{
    public static readonly Error CanNotFindTeam = Error.NotFound(
        TeamErrorCode.CanNotFindTeam,
        "Can not find team");
    
    public static readonly Error UserAlreadyExistedInTeam = Error.Validation(
        TeamErrorCode.UserAlreadyExistedInTeam,
        "This user already existed in a team.");
}
