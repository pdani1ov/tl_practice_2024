using System.Data;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Theatre
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public string Address { get; private init; }
    public DateOnly OpeningDate { get; private init; }
    public string PhoneNumber { get; private set; }
    public string Description { get; private set; }

    [JsonIgnore]
    public IReadOnlyList<WorkingHours> WorkingHours { get; private init; } = new List<WorkingHours>();
    [JsonIgnore]
    public IReadOnlyList<Play> Plays { get; private init; } = new List<Play>();

    public Theatre(
        string name,
        string address,
        DateOnly openingDate,
        string phoneNumber,
        string description )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( $"{nameof( name )} cannot be null or white spaces." );
        }
        if ( string.IsNullOrWhiteSpace( address ) )
        {
            throw new ArgumentNullException( $"{nameof( address )} cannot be null or white spaces." );
        }
        if ( string.IsNullOrWhiteSpace( phoneNumber ) )
        {
            throw new ArgumentNullException( $"{nameof( phoneNumber )} cannot be null or white spaces." );
        }
        Name = name;
        Address = address;
        OpeningDate = openingDate;
        PhoneNumber = phoneNumber;
        Description = description;
    }

    public void Update( string? name, string? phoneNumber, string? description )
    {
        if ( !string.IsNullOrWhiteSpace( name ) )
        {
            Name = name;
        }
        if ( !string.IsNullOrWhiteSpace( phoneNumber ) )
        {
            PhoneNumber = phoneNumber;
        }
        if ( !string.IsNullOrEmpty( description ) )
        {
            Description = description;
        }
    }
}
