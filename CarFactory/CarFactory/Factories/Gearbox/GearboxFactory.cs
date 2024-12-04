using CarFactory.Models.Gearbox;

namespace CarFactory.Factories.Gearbox;

public class GearboxFactory : IGearboxFactory
{
    public IGearbox CreateGearbox( string description )
    {
        switch ( description )
        {
            case "automatic":
                return new AutomaticGearbox();
            case "mechanical":
                return new MechanicalGearbox();
            case "variator":
                return new Variator();
            default:
                throw new ArgumentException( $"Unknown type of car gearbox - {description}" );
        }
    }
}
