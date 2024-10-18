using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Composition
{
    public int Id { get; private init; }
    public string Name { get; private init; }
    public string Description { get; private init; }
    public string CharactersInfo { get; private init; }

    public int AuthorId { get; private init; }
    [JsonIgnore]
    public IReadOnlyList<Play> Plays { get; private init; } = new List<Play>();

    public Composition(
        string name,
        string description,
        string charactersInfo,
        int authorId )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( $"{nameof( name )} cannot be null or white spaces." );
        }
        Name = name;
        Description = description;
        CharactersInfo = charactersInfo;
        AuthorId = authorId;
    }
}
