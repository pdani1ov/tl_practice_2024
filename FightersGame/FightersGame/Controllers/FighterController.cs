using Fighters.Extensions;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Controllers
{
    public class FighterController : IFighterController
    {
        private List<IFighter> _fighters = new List<IFighter>();

        public IReadOnlyList<IFighter> GetFighters() => _fighters;

        public IFighter CreateFighter()
        {
            string name = GetFighterName();
            IRace race = GetRace();
            IFighter fighter = GetFighterWithType( race, name );

            IArmor? armor = GetArmor();
            if ( armor != null )
            {
                fighter.SetArmor( armor );
            }

            IWeapon? weapon = GetWeapon();
            if ( weapon != null )
            {
                fighter.SetWeapon( weapon );
            }
            _fighters.Add( fighter );

            return fighter;
        }

        public void Clear()
        {
            _fighters.Clear();
        }

        public void Fight()
        {
            const string firstFighterDeathMsg = "Первый боец {fighterName} погиб";
            const string secondFighterDeathMsg = "Второй боец {fighterName} погиб";
            const string firstFighterAttackMsg = "Первый боец нанес урон - {causedDamage}. " +
                "Второй боец получил урон - {receivedDamage}.";
            const string secondFighterAttackMsg = "Второй боец нанес урон - {causedDamage}. " +
                "Первый боец получил урон - {receivedDamage}.";

            List<IFighter> leaveFighters = _fighters.Where( fighter => fighter.IsAlive() ).ToList();

            //Поверяем, что количество живых бойцов больше 2-х
            if ( leaveFighters.Count < 2 )
            {
                Console.WriteLine( "Количество живых бойцов меньше 2-х" );
                return;
            }

            //Получаем первого бойца
            Console.WriteLine( "Введите номер первого бойца, который будет начинать атаку." );
            IFighter fighter1 = GetFighter();

            //Получаем второго бойца и проверяем, что это не первый боец
            Console.WriteLine( "Введите номер второго бойца." );
            IFighter fighter2 = GetFighter();
            while ( fighter1 == fighter2 )
            {
                Console.WriteLine( "Вы ввели номер первого бойца. Он сам с собой биться не может." );
                fighter2 = GetFighter();
            }

            while ( true )
            {
                if ( AtackExchange( fighter1, fighter2, secondFighterDeathMsg, firstFighterAttackMsg )
                   || AtackExchange( fighter2, fighter1, firstFighterDeathMsg, secondFighterAttackMsg ) )
                {
                    return;
                }
            }
        }

        private bool AtackExchange(
            IFighter attackFighter,
            IFighter defenceFighter,
            string fighterDeathMsg,
            string attackExchangeMsg )
        {
            int fighterDamage = attackFighter.CalculateDamage();
            int receivedByDefenceFighterDamage = defenceFighter.TakeDamage( fighterDamage );

            if ( !defenceFighter.IsAlive() )
            {
                Console.WriteLine( fighterDeathMsg.Replace( "{fighterName}", defenceFighter.Name ) );
                return true;
            }

            string msg = attackExchangeMsg
                .Replace( "{causedDamage}", fighterDamage.ToString() )
                .Replace( "{receivedDamage}", receivedByDefenceFighterDamage.ToString() );

            Console.WriteLine( msg );
            return false;
        }

        private IFighter GetFighterWithType( IRace race, string name )
        {
            const string listOfFighterTypesMsg = """
            СПИСОК ТИПОВ БОЙЦОВ
            1 - рыцарь
            2 - варвар
            3 - наёмник
            """;

            while ( true )
            {
                Console.WriteLine( listOfFighterTypesMsg );

                string? str = Console.ReadLine();

                switch ( str )
                {
                    case "1":
                        return new Knight( race, name );
                    case "2":
                        return new Barbarian( race, name );
                    case "3":
                        return new Mercenary( race, name );
                    default:
                        Console.WriteLine( "Вы ввели некорректное сообщение. Введите еще раз" );
                        break;
                }
            }
        }

        private string GetFighterName()
        {
            Console.Write( "Введите имя бойца: " );

            while ( true )
            {
                string? str = Console.ReadLine();

                if ( string.IsNullOrWhiteSpace( str ) )
                {
                    Console.WriteLine( "Вы ввели некоррекстное имя. Введите имя заново." );
                    continue;
                }

                return str.Trim();
            }
        }

        private IRace GetRace()
        {
            const string listOfRacesMsg = """
            СПИСОК РАС
            1 - человек
            2 - гном
            3 - эльф
            """;

            Console.WriteLine( "Выбирите расу бойца." );

            while ( true )
            {
                Console.WriteLine( listOfRacesMsg );
                string? str = Console.ReadLine();
                switch ( str )
                {
                    case "1":
                        return new Human();
                    case "2":
                        return new Dwarf();
                    case "3":
                        return new Elf();
                    default:
                        Console.WriteLine( "Вы ввели некорректное сообщение. Введите еще раз." );
                        break;
                }
            }
        }

        private IArmor? GetArmor()
        {
            const string listOfRacesMsg = """
            СПИСОК БРОНИ
            1 - кольчуга
            2 - стальная броня
            3 - без брони
            """;

            Console.WriteLine( "Выбирите броню для бойца." );

            while ( true )
            {
                Console.WriteLine( listOfRacesMsg );
                string? str = Console.ReadLine();
                switch ( str )
                {
                    case "1":
                        return new Chainmail();
                    case "2":
                        return new SteelArmor();
                    case "3":
                        return null;
                    default:
                        Console.WriteLine( "Вы ввели некорректное сообщение. Введите еще раз." );
                        break;
                }
            }
        }

        private IWeapon? GetWeapon()
        {
            const string listOfRacesMsg = """
            СПИСОК ОРУЖИЯ
            1 - меч
            2 - кинжал
            3 - без оружия
            """;

            Console.WriteLine( "Выбирите броню для бойца." );

            while ( true )
            {
                Console.WriteLine( listOfRacesMsg );
                string? str = Console.ReadLine();
                switch ( str )
                {
                    case "1":
                        return new Sword();
                    case "2":
                        return new Dagger();
                    case "3":
                        return null;
                    default:
                        Console.WriteLine( "Вы ввели некорректное сообщение. Введите еще раз." );
                        break;
                }
            }
        }

        private IFighter GetFighter()
        {
            Console.Write( "Введите номер бойца: " );

            while ( true )
            {
                string? str = Console.ReadLine();
                int index = 0;
                if ( !int.TryParse( str, out index ) )
                {
                    Console.WriteLine( "Вы ввели не число. Введите номер бойца еще раз" );
                    continue;
                }
                if ( index >= 0 && index < _fighters.Count )
                {
                    return _fighters[ index ];
                }
                Console.WriteLine( "Вы ввели некорректный номер бойца. Введите номер бойца еще раз" );
                continue;
            }
        }
    }
}