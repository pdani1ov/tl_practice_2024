using Fighters.Controllers;
using Fighters.Extensions;
using Fighters.Models.Fighters;

namespace Fighters.Managers
{
    public class GameManager : IGameManager
    {
        private IFighterController _fighterController = new FighterController();

        public void Play()
        {
            bool isExit = false;

            PrintMenu();

            while ( !isExit )
            {
                string? str = Console.ReadLine();
                switch ( str )
                {
                    case "fight":
                        _fighterController.Fight();
                        break;
                    case "add":
                        _fighterController.CreateFighter();
                        break;
                    case "show":
                        PrintFighterList();
                        break;
                    case "clear":
                        _fighterController.Clear();
                        break;
                    case "help":
                        PrintMenu();
                        break;
                    case "exit":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine( "Unknown command" );
                        break;
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine( "СПИСОК КОМАНД" );
            Console.WriteLine( "fight - устроить бой" );
            Console.WriteLine( "add - добавить бойца" );
            Console.WriteLine( "show - показать список бойцов" );
            Console.WriteLine( "clear - очистить список" );
            Console.WriteLine( "help - показать список команд" );
            Console.WriteLine( "exit - конец игры" );
        }

        private void PrintFighterList()
        {
            List<IFighter> fighters = _fighterController.GetFighters();

            if ( fighters.Count == 0 )
            {
                Console.WriteLine( "Список бойцов пуст." );
                return;
            }

            for ( int i = 0; i < fighters.Count; i++ )
            {
                Console.WriteLine( $"{i} - {fighters[ i ].Info()}" );
            }
        }
    }
}
