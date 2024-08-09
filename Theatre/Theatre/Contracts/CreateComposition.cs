namespace WebAPI.Contracts;

public class CreateComposition
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CharacterInfo { get; set; }
    public int AuthorId { get; set; }
}
