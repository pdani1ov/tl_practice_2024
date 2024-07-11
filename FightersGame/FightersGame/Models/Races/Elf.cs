namespace Fighters.Models.Races
{
    public class Elf : IRace
    {
        public int Damage => 5;
        public int Health => 85;
        public int Armor => 0;
        public string Type => "Эльф";
    }
}
