using Fighters.Models.Fighters;

namespace Fighters.Controllers
{
    public interface IFighterController
    {
        public IReadOnlyList<IFighter> GetFighters();
        public IFighter CreateFighter();
        public void Clear();
        public void Fight();
    }
}
