using CarFactory.Extensions;
using CarFactory.Factories.CarsFactory;
using CarFactory.Models.Cars;

namespace CarFactory.Managers;

public class CarManager : ICarManager
{
    private List<ICar> _cars = new List<ICar>();
    private ICarFactory _carFactory = new CarFactory.Factories.CarsFactory.CarFactory();

    public void Run()
    {
        Console.WriteLine( " --- CAR MANAGER --- " );
        PrintMenu();
        string? input;
        while ( ( input = Console.ReadLine() ) != "exit" )
        {
            if ( input == null )
            {
                Console.WriteLine( "Incorrect command is null" );
                continue;
            }

            try
            {
                ProcessCommand( input );
            }
            catch ( ArgumentException e )
            {
                Console.WriteLine( e.Message );
            }
        }
    }

    private void ProcessCommand( string input )
    {
        List<string> partsOfCommand = input.Split( ' ', 2 ).ToList();

        if ( partsOfCommand.Count == 0 )
        {
            throw new ArgumentException( "Command is empty" );
        }

        string command = partsOfCommand[ 0 ];
        switch ( command )
        {
            case "add":
                if ( partsOfCommand.Count != 2 )
                {
                    throw new ArgumentException( "No add command parameters" );
                }
                ICar newCar = _carFactory.CreateCar( partsOfCommand[ 1 ] );
                _cars.Add( newCar );
                Console.WriteLine( "Your car has been successfully created" );
                break;
            case "show":
                PrintCarList();
                break;
            case "help":
                PrintMenu();
                break;
            default:
                Console.WriteLine( "Unknown command" );
                break;
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine( "add {carbody} {engine} {gearbox} {color} {steering wheel position} - add new car" );
        Console.WriteLine( "show - show list of car" );
        Console.WriteLine( "help - show info about manager" );
        Console.WriteLine( "exit - exit from car manager" );
        Console.WriteLine( "carbody types - coupe | minivan | roadster | sedan" );
        Console.WriteLine( "engine types - diesel | petrol" );
        Console.WriteLine( "gearbox types - automatic | variator | mechanical" );
        Console.WriteLine( "colors - black | white | red | green | blue" );
        Console.WriteLine( "engine types - diesel | petrol" );
        Console.WriteLine( "car steering wheel position - left | right" );
    }

    private void PrintCarList()
    {
        if ( _cars.Count == 0 )
        {
            Console.WriteLine( "List of cars is empty" );
            return;
        }

        for ( int i = 0; i < _cars.Count; i++ )
        {
            Console.WriteLine( $" --- {i + 1} ---" );
            Console.WriteLine( _cars[ i ].Info() );
        }
    }
}
