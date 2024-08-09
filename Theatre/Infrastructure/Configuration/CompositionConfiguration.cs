using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class CompositionConfiguration : IEntityTypeConfiguration<Composition>
{
    public void Configure( EntityTypeBuilder<Composition> builder )
    {
        builder.ToTable( nameof( Composition ) )
            .HasKey( c => c.Id );

        builder.Property( c => c.Name )
            .HasMaxLength( 100 )
            .IsRequired();

        builder.Property( c => c.Description )
            .HasMaxLength( 255 )
            .IsRequired();

        builder.Property( c => c.CharactersInfo )
            .HasMaxLength( 255 )
            .IsRequired();

        builder.HasMany( c => c.Plays )
            .WithOne( p => p.Composition )
            .HasForeignKey( p => p.CompositionId );
    }
}
