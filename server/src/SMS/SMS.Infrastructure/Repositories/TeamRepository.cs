using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Teams;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class TeamRepository(ApplicationDbContext context) : ITeamRepository
{
    public async Task<IReadOnlyList<Team>> GetTeamsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await context.Set<Team>()
            .Where(t => t.TeamMembers.Any(m => m.UserId == userId))
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> VerifyExistedTeamByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Team>()
            .AnyAsync(x => x.Id == id, cancellationToken); 
    }

    public async Task<Team?> FindTeamByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Team>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);    
    }

    public async Task<Team> AddTeamAsync(Team team, CancellationToken cancellationToken)
    {
        var result = await context.Set<Team>().AddAsync(team, cancellationToken);
        
        return result.Entity;
    }
}