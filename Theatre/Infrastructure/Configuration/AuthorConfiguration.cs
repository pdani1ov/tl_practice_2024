using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure( EntityTypeBuilder<Author> builder )
    {
        builder.ToTable( nameof( Author ) )
            .HasKey( a => a.Id );

        builder.Property( a => a.FirstName )
            .HasMaxLength( 50 )
            .IsRequired();

        builder.Property( a => a.LastName )
            .HasMaxLength( 50 )
            .IsRequired();

        builder.Property( a => a.BirthDate )
            .IsRequired();

        builder.HasMany( a => a.Compositions )
            .WithOne()
            .HasForeignKey( c => c.AuthorId );
    }
}
