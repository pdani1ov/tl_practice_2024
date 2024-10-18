namespace WebAPI.Contracts;

public class CreateWorkingHours
{
    public byte Day { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
    public int TheatreId { get; set; }
}
