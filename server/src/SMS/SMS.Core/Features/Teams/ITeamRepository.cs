namespace SMS.Core.Features.Teams;

public interface ITeamRepository
{
    Task<Team?> FindTeamByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Team> AddTeamAsync(Team team, CancellationToken cancellationToken);
}