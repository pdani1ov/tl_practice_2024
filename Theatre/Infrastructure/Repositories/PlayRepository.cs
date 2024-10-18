using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PlayRepository : Repository<Play>, IPlayRepository
{
    public PlayRepository( TheatreDbContext dbContext )
        : base( dbContext )
    { }

    public List<Play> GetPlaysInTimePeriod( DateTime start, DateTime end )
    {
        return _dbContext.Set<Play>()
            .Where( p => p.StartDate >= start && p.EndDate <= end )
            .Include( p => p.Composition )
            .Include( p => p.Theatre )
            .ToList();
    }
}
