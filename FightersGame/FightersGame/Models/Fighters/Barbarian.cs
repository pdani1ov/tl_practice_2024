using Fighters.Models.Races;

namespace Fighters.Models.Fighters
{
    public class Barbarian : BaseFighter
    {
        public Barbarian( IRace race, string name ) : base( race, name )
        { }

        public override string Type => "Варвар";
        public override int TypeDamage => 5;
        public override int TypeHealth => 15;
    }
}
