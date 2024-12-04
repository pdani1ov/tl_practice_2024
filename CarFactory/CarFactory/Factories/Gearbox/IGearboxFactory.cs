using CarFactory.Models.Gearbox;

namespace CarFactory.Factories.Gearbox;

public interface IGearboxFactory
{
    public IGearbox CreateGearbox( string description );
}
