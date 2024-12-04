namespace CarFactory.Models.Gearbox;

public class AutomaticGearbox : IGearbox
{
    public string Name => "automatic";
    public int ExtraSpeed => 30;
    public int ExtraGears => 2;
}
