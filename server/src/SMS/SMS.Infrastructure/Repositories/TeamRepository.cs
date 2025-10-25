using SMS.Core.Common;
using SMS.Core.Features.Teams;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class TeamRepository(ApplicationDbContext context) : ITeamRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public IUnitOfWork UnitOfWork => _context;

    public async Task<Team> AddTeamAsync(Team team, CancellationToken cancellationToken)
    {
        var result = await _context.Set<Team>().AddAsync(team, cancellationToken);
        
        return result.Entity;
    }
}