using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class WorkingHoursConfiguration : IEntityTypeConfiguration<WorkingHours>
{
    public void Configure( EntityTypeBuilder<WorkingHours> builder )
    {
        builder.ToTable( nameof( WorkingHours ) )
            .HasKey( wh => wh.Id );

        builder.Property( wh => wh.Day )
            .IsRequired();

        builder.Property( wh => wh.Start )
            .IsRequired();

        builder.Property( wh => wh.End )
            .IsRequired();

    }
}
