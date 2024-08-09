using Domain.Entities;

namespace Domain.Repositories;

public interface IPlayRepository : IRepository<Play>
{
    public List<Play> GetPlaysInTimePeriod( DateTime start, DateTime end );
}
