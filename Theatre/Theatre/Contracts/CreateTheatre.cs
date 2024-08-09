namespace WebAPI.Contracts;

public class CreateTheatre
{
    public string Name { get; set; }
    public string Address { get; set; }
    public DateOnly OpeningDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
}
