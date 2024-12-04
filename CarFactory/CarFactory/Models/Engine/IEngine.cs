namespace CarFactory.Models.Engine;

public interface IEngine
{
    public string Name { get; }
    public int Speed { get; }
    public int GearsQuantity { get; }
}
