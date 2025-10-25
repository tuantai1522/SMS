namespace SMS.Core.Features.Teams;

public interface ITeamRepository
{
    Task<Team> AddTeamAsync(Team team, CancellationToken cancellationToken);
}