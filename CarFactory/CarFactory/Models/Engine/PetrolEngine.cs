namespace CarFactory.Models.Engine;

public class PetrolEngine : IEngine
{
    public string Name => "petrol";
    public int Speed => 300;
    public int GearsQuantity => 5;
}
