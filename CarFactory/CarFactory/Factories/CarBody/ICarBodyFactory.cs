using CarFactory.Models.CarBody;

namespace CarFactory.Factories.CarBody;

public interface ICarBodyFactory
{
    public ICarBody CreateCarBody( string description );
}
