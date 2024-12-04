namespace Fighters.Models.Races
{
    public class Dwarf : IRace
    {
        public int Damage => 1;
        public int Health => 80;
        public int Armor => 10;
        public string Type => "Гном";
    }
}
