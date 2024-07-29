namespace CarFactory.Models.Gearbox;

public class MechanicalGearbox : IGearbox
{
    public string Name => "mechanical";
    public int ExtraSpeed => 0;
    public int ExtraGears => 0;
}
