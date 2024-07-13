using CarFactory.Models.CarBody;

namespace CarFactory.Factories.CarBody;

public class CarBodyFactory : ICarBodyFactory
{
    public ICarBody CreateCarBody( string description )
    {
        switch ( description )
        {
            case "sedan":
                return new Sedan();
            case "coupe":
                return new Coupe();
            case "roadster":
                return new Roadster();
            case "minivan":
                return new Minivan();
            default:
                throw new ArgumentException( $"Unknown car body - {description}" );
        }
    }
}
