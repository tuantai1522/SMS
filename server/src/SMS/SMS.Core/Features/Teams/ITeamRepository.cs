namespace SMS.Core.Features.Teams;

public interface ITeamRepository
{
    Task<IReadOnlyList<Team>> GetTeamsByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    
    Task<bool> VerifyExistedTeamByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Team?> FindTeamByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Team> AddTeamAsync(Team team, CancellationToken cancellationToken);
}