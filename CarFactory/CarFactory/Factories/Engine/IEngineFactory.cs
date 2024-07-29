using CarFactory.Models.Engine;

namespace CarFactory.Factories.Engine;

public interface IEngineFactory
{
    public IEngine CreateEngine( string description );
}
