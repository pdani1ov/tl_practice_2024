namespace WebAPI.Contracts;

public class GetPlaysInTimePeriod
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<PlayInTimePeriodInfo> playsInfo { get; set; }
}
