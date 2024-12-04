using Fighters.Models.Races;

namespace Fighters.Models.Fighters
{
    public class Knight : BaseFighter
    {
        public Knight( IRace race, string name ) : base( race, name )
        { }

        public override string Type => "Рыцарь";
        public override int TypeDamage => 10;
        public override int TypeHealth => 30;
    }
}
