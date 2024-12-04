using CarFactory.Factories.CarBody;
using CarFactory.Factories.Engine;
using CarFactory.Factories.Gearbox;
using CarFactory.Models.CarBody;
using CarFactory.Models.CarColor;
using CarFactory.Models.Cars;
using CarFactory.Models.CarSteeringWheelPosition;
using CarFactory.Models.Engine;
using CarFactory.Models.Gearbox;

namespace CarFactory.Factories.CarsFactory;

public class CarFactory : ICarFactory
{
    private ICarBodyFactory _carBodyFactory = new CarBodyFactory();
    private IEngineFactory _engineFactory = new EngineFactory();
    private IGearboxFactory _gearboxFactory = new GearboxFactory();

    public ICar CreateCar( string description )
    {
        List<string> partsOfDescription = description.Split( ' ' ).ToList();
        if ( partsOfDescription.Count != 5 )
        {
            throw new ArgumentException( "Incorrect configuration of car. " +
                "You need to enter it like this " +
                "\"add {carbody} {engine} {gearbox} {color} {steering wheel position}\"" );
        }

        ICarBody carBody = _carBodyFactory.CreateCarBody( partsOfDescription[ 0 ] );
        IEngine engine = _engineFactory.CreateEngine( partsOfDescription[ 1 ] );
        IGearbox gearbox = _gearboxFactory.CreateGearbox( partsOfDescription[ 2 ] );
        Color color = StringToColor( partsOfDescription[ 3 ] );
        SteeringWheelPosition steeringWheelPosition = StringToSteeringWheelPosition( partsOfDescription[ 4 ] );

        return new Car( color, engine, gearbox, carBody, steeringWheelPosition );
    }

    private Color StringToColor( string colorStr )
    {
        switch ( colorStr )
        {
            case "white":
                return Color.White;
            case "black":
                return Color.Black;
            case "red":
                return Color.Red;
            case "green":
                return Color.Green;
            case "blue":
                return Color.Blue;
            default:
                throw new ArgumentException( $"Unknown car color - {colorStr}" );
        }
    }

    private SteeringWheelPosition StringToSteeringWheelPosition( string posStr )
    {
        switch ( posStr )
        {
            case "left":
                return SteeringWheelPosition.Left;
            case "right":
                return SteeringWheelPosition.Right;
            default:
                throw new ArgumentException( $"Unknown car steering wheel position - {posStr}" );
        }
    }
}
