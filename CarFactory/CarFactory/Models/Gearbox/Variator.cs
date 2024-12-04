namespace CarFactory.Models.Gearbox;

public class Variator : IGearbox
{
    public string Name => "variator";
    public int ExtraSpeed => 10;
    public int ExtraGears => 1;
}
