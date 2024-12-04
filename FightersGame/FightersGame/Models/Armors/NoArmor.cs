namespace Fighters.Models.Armors
{
    public class NoArmor : IArmor
    {
        public int Damage => 0;
        public string Type => "Без брони";
    }
}
