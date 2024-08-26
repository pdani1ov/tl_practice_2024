using CarFactory.Models.Cars;

namespace CarFactory.Extensions;

public static class ICarExtensions
{
    public static string Info( this ICar car )
    {
        return "------\n" +
            $"Сar body type - {car.CarBody.Name}.\n" +
            $"Сar engine type - {car.Engine.Name}.\n" +
            $"Car gearbox type - {car.Gearbox.Name}.\n" +
            $"Car color - {car.Color.ConvertToString()}.\n" +
            $"Car steering wheel position - {car.SteeringWheelPos.ConvertToString()}.\n" +
            $"Max speed of car - {car.MaxSpeed}.\n" +
            $"Quantity of car gears - {car.GearsQuantity}.\n" +
            "------";
    }
}
