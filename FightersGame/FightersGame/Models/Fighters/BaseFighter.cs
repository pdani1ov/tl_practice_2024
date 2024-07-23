using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public abstract class BaseFighter : IFighter
    {
        private string _name;
        private readonly IRace _race;
        private IArmor _armor = new NoArmor();
        private IWeapon _weapon = new Fists();

        public BaseFighter( IRace race, string name )
        {
            _race = race;
            _name = name;
            CurrentHealth = this.MaxHealth;
        }

        public string Name => _name;
        public IWeapon Weapon => _weapon;
        public IArmor Armor => _armor;
        public IRace Race => _race;

        public abstract string Type { get; }
        public abstract int TypeDamage { get; }
        public abstract int TypeHealth { get; }

        public int MaxHealth => _race.Health + TypeHealth;
        public int CurrentHealth { get; private set; }

        public void SetArmor( IArmor armor )
        {
            _armor = armor;
        }
        public void SetWeapon( IWeapon weapon )
        {
            _weapon = weapon;
        }

        public int CalculateDamage()
        {
            const int MinExtraDamage = -20;
            const int MaxExtraDamage = 10;

            int fighterDamage = _race.Damage + TypeDamage + _armor.Damage;
            double extraDamage = Random.Shared.Next( MinExtraDamage, MaxExtraDamage ) / 100 * fighterDamage;

            fighterDamage += ( int )extraDamage;

            bool isCriticalDamage = Random.Shared.Next( 1, 10 ) < 2;

            if ( isCriticalDamage )
            {
                fighterDamage *= 2;
            }

            return fighterDamage;
        }

        public int CalculateArmor()
        {
            return _race.Armor + _armor.Damage;
        }

        public int TakeDamage( int damage )
        {
            if ( CurrentHealth == 0 )
            {
                return 0;
            }

            int receivedDamage = CalculateArmor() > damage ? 1 : damage - CalculateArmor();

            if ( receivedDamage > CurrentHealth )
            {
                receivedDamage = CurrentHealth;
                CurrentHealth = 0;
                return receivedDamage;
            }

            CurrentHealth -= receivedDamage;
            return receivedDamage;
        }
    }
}
