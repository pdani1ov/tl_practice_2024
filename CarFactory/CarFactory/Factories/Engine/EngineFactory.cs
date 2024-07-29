using CarFactory.Models.Engine;

namespace CarFactory.Factories.Engine;

public class EngineFactory : IEngineFactory
{
    public IEngine CreateEngine( string description )
    {
        switch ( description )
        {
            case "petrol":
                return new PetrolEngine();
            case "diesel":
                return new DieselEngine();
            default:
                throw new ArgumentException( $"Unknown type of engine - {description}" );
        }
    }
}
