namespace CarFactory.Models.Engine;

public class DieselEngine : IEngine
{
    public string Name => "diesel";
    public int Speed => 220;
    public int GearsQuantity => 4;
}
