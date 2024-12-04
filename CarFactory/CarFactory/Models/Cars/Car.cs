using CarFactory.Models.CarColor;
using CarFactory.Models.CarBody;
using CarFactory.Models.Engine;
using CarFactory.Models.Gearbox;
using CarFactory.Models.CarSteeringWheelPosition;

namespace CarFactory.Models.Cars;

public class Car : ICar
{
    private Color _color;
    private IEngine _engine;
    private IGearbox _gearbox;
    private ICarBody _carBody;
    private SteeringWheelPosition _steeringWheelPosition;

    public Car(
        Color color,
        IEngine engine,
        IGearbox gearbox,
        ICarBody carBody,
        SteeringWheelPosition steeringWheelPosition )
    {
        _color = color;
        _engine = engine;
        _gearbox = gearbox;
        _carBody = carBody;
        _steeringWheelPosition = steeringWheelPosition;
    }

    public Color Color => _color;
    public IEngine Engine => _engine;
    public IGearbox Gearbox => _gearbox;
    public ICarBody CarBody => _carBody;
    public SteeringWheelPosition SteeringWheelPos => _steeringWheelPosition;

    public int MaxSpeed => _engine.Speed + _gearbox.ExtraSpeed + _carBody.ExtraSpeed;
    public int GearsQuantity => _engine.GearsQuantity + _gearbox.ExtraGears;
}