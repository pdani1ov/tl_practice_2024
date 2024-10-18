using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Author
{
    public int Id { get; private init; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly BirthDate { get; private init; }

    [JsonIgnore]
    public IReadOnlyList<Composition> Compositions { get; private init; } = new List<Composition>();

    public Author(
        string firstName,
        string lastName,
        DateOnly birthDate )
    {
        if ( string.IsNullOrWhiteSpace( firstName ) )
        {
            throw new ArgumentNullException( $"{nameof( firstName )} cannot be null or white spaces." );
        }

        if ( string.IsNullOrWhiteSpace( lastName ) )
        {
            throw new ArgumentException( $"{nameof( lastName )} cannot be null or white spaces." );
        }
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}
