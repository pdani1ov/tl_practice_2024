using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class TheatreConfiguration : IEntityTypeConfiguration<Theatre>
{
    public void Configure( EntityTypeBuilder<Theatre> builder )
    {
        builder.ToTable( nameof( Theatre ) )
            .HasKey( t => t.Id );

        builder.Property( t => t.Name )
            .HasMaxLength( 100 )
            .IsRequired();

        builder.Property( t => t.Address )
            .HasMaxLength( 100 )
            .IsRequired();

        builder.Property( t => t.OpeningDate )
            .IsRequired();

        builder.Property( t => t.PhoneNumber )
            .HasMaxLength( 20 )
            .IsRequired();

        builder.Property( t => t.Description )
            .HasMaxLength( 255 )
            .IsRequired();

        builder.HasMany( t => t.WorkingHours )
            .WithOne()
            .HasForeignKey( wh => wh.TheatreId );

        builder.HasMany( t => t.Plays )
            .WithOne( p => p.Theatre )
            .HasForeignKey( p => p.TheatreId );
    }
}
