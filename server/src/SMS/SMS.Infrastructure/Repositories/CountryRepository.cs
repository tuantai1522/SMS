using Microsoft.EntityFrameworkCore;
using SMS.Core.Common;
using SMS.Core.Features.Countries;
using SMS.Infrastructure.Database;

namespace SMS.Infrastructure.Repositories;

public sealed class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IReadOnlyList<Country>> GetCountriesAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<Country>()
            .ToListAsync(cancellationToken);    
    }

    public async Task<IReadOnlyList<City>> GetCitiesByCountryIdAsync(int countryId, CancellationToken cancellationToken)
    {
        return await _context.Set<Country>()
            .Where(c => c.Id == countryId)
            .SelectMany(c => c.Cities)
            .ToListAsync(cancellationToken);  
    }
}