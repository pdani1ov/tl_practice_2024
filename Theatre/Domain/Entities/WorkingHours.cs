namespace Domain.Entities;
public class WorkingHours
{
    public int Id { get; private init; }

    /*
    0 - sunday
    1 - monday
    2 - tuesday
    3 - wednesday
    4 - thursday
    5 - friday
    6 - saturday
    */
    public byte Day { get; private init; }
    public TimeOnly Start { get; private init; }
    public TimeOnly End { get; private init; }

    public int TheatreId { get; private init; }

    public WorkingHours(
        byte day,
        TimeOnly start,
        TimeOnly end,
        int theatreId )
    {
        if ( day > 6 )
        {
            throw new ArgumentException( $"{nameof( day )} cannot be more than 6." );
        }
        Day = day;
        Start = start;
        End = end;
        TheatreId = theatreId;
    }
}
