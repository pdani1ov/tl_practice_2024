using CarFactory.Models.Cars;

namespace CarFactory.Factories.CarsFactory;

public interface ICarFactory
{
    public ICar CreateCar( string description );
}
