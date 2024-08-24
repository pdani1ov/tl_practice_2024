namespace WebAPI.Contracts;

public class CreateAuthor
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}
