using CarFactory.Models.CarBody;
using CarFactory.Models.CarColor;
using CarFactory.Models.Engine;
using CarFactory.Models.Gearbox;
using CarFactory.Models.CarSteeringWheelPosition;

namespace CarFactory.Models.Cars;

public interface ICar
{
    public Color Color { get; }
    public IEngine Engine { get; }
    public IGearbox Gearbox { get; }
    public ICarBody CarBody { get; }
    public SteeringWheelPosition SteeringWheelPos { get; }

    public int MaxSpeed { get; }
    public int GearsQuantity { get; }
}
