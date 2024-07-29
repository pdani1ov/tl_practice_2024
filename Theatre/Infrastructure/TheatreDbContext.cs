using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class TheatreDbContext : DbContext
{
    public TheatreDbContext( DbContextOptions<TheatreDbContext> options )
        : base( options )
    { }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfiguration( new AuthorConfiguration() );
        modelBuilder.ApplyConfiguration( new CompositionConfiguration() );
        modelBuilder.ApplyConfiguration( new WorkingHoursConfiguration() );
        modelBuilder.ApplyConfiguration( new PlayConfiguration() );
        modelBuilder.ApplyConfiguration( new TheatreConfiguration() );
    }
}
