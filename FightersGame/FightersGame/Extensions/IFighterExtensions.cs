using Fighters.Models.Fighters;

namespace Fighters.Extensions
{
    public static class IFighterExtensions
    {
        public static bool IsAlive( this IFighter fighter ) => fighter.CurrentHealth > 0;

        public static string Info( this IFighter fighter )
        {
            string info = $"Имя бойца - {fighter.Name}. Тип бойца - {fighter.Type}. Раса - {fighter.Race.Type}. Оружие - {fighter.Weapon.Type}. Броня - {fighter.Armor.Type}. ";
            if ( fighter.IsAlive() )
            {
                info += $"Статус - жив. Текущее здоровье - {fighter.CurrentHealth}";
            }
            else
            {
                info += "Статус - мертв";
            }
            return info;
        }
    }
}
