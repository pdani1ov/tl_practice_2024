using Fighters.Models.Races;

namespace Fighters.Models.Fighters
{
    public class Mercenary : BaseFighter
    {
        public Mercenary( IRace race, string name ) : base( race, name )
        { }

        public override string Type => "Наёмник";
        public override int TypeDamage => 10;
        public override int TypeHealth => 20;
    }
}
