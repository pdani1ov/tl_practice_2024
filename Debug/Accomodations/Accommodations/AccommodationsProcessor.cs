using Accommodations.Commands;
using Accommodations.Dto;

namespace Accommodations;

public static class AccommodationsProcessor
{
    private static BookingService _bookingService = new();
    private static Dictionary<int, ICommand> _executedCommands = new();
    private static int s_commandIndex = 0;

    public static void Run()
    {
        Console.WriteLine( "Booking Command Line Interface" );
        Console.WriteLine( "Commands:" );
        Console.WriteLine( "'book <UserId> <Category> <StartDate> <EndDate> <Currency>' - to book a room" );
        Console.WriteLine( "'cancel <BookingId>' - to cancel a booking" );
        Console.WriteLine( "'undo' - to undo the last command" );
        Console.WriteLine( "'find <BookingId>' - to find a booking by ID" );
        Console.WriteLine( "'search <StartDate> <EndDate> <CategoryName>' - to search bookings" );
        Console.WriteLine( "'exit' - to exit the application" );

        string input;
        while ( ( input = Console.ReadLine() ) != "exit" )
        {
            try
            {
                ProcessCommand( input );
            }
            catch ( ArgumentException ex )
            {
                Console.WriteLine( $"Error: {ex.Message}" );
            }
        }
    }

    private static void ProcessCommand( string input )
    {
        string[] parts = input.Split( ' ' );
        string commandName = parts[ 0 ];

        switch ( commandName )
        {
            case "book":
                if ( parts.Length != 6 )
                {
                    Console.WriteLine( "Invalid number of arguments for booking." );
                    return;
                }

                CurrencyDto currency = ( CurrencyDto )Enum.Parse( typeof( CurrencyDto ), parts[ 5 ], true );
                //Добавил парсинг даты с проверкой на корректность даты. В случае, когда дата некорректна,
                //выбрасывается ArgumentException.
                DateTime start = ParseDate( parts[ 3 ], "Incorrect start date for booking." );
                DateTime end = ParseDate( parts[ 4 ], "Incorrect end date for booking." );
                //Добавил парсинг числа с проверкой на его корректность. В случае, когда число некорректно,
                //выбрасывается ArgumentException.
                int userId = ParseInt( parts[ 1 ], "Incorrect user ID for booking." );

                BookingDto bookingDto = new BookingDto(
                    userId,
                    parts[ 2 ],
                    start,
                    end,
                    currency );

                BookCommand bookCommand = new( _bookingService, bookingDto );
                bookCommand.Execute();
                _executedCommands.Add( ++s_commandIndex, bookCommand );
                Console.WriteLine( "Booking command run is successful." );
                break;

            case "cancel":
                if ( parts.Length != 2 )
                {
                    Console.WriteLine( "Invalid number of arguments for canceling." );
                    return;
                }
                //Добавил парсинг id брони с проверкой. Когда id некорректен, то выбрасывается ArgumentException
                Guid bookingId = ParseBookingId( parts[ 1 ] );
                CancelBookingCommand cancelCommand = new( _bookingService, bookingId );
                cancelCommand.Execute();
                _executedCommands.Add( ++s_commandIndex, cancelCommand );
                Console.WriteLine( "Cancellation command run is successful." );
                break;

            case "undo":
                if ( _executedCommands.Count == 0 )
                {
                    Console.WriteLine( "Command history is empty." );
                    return;
                }
                _executedCommands[ s_commandIndex ].Undo();
                _executedCommands.Remove( s_commandIndex );
                s_commandIndex--;
                Console.WriteLine( "Last command undone." );

                break;
            case "find":
                if ( parts.Length != 2 )
                {
                    Console.WriteLine( "Invalid arguments for 'find'. Expected format: 'find <BookingId>'" );
                    return;
                }
                //Добавил парсинг id брони с проверкой. Когда id некорректен, то выбрасывается ArgumentException
                Guid id = ParseBookingId( parts[ 1 ] );
                FindBookingByIdCommand findCommand = new( _bookingService, id );
                findCommand.Execute();
                break;

            case "search":
                if ( parts.Length != 4 )
                {
                    Console.WriteLine( "Invalid arguments for 'search'. Expected format: 'search <StartDate> <EndDate> <CategoryName>'" );
                    return;
                }
                //Добавил парсинг даты с проверкой на корректность даты. В случае, когда дата некорректна,
                //выбрасывается ArgumentException.
                DateTime startDate = ParseDate( parts[ 1 ], "Incorrect start date for booking." );
                DateTime endDate = ParseDate( parts[ 2 ], "Incorrect end date for booking." );
                string categoryName = parts[ 3 ];
                SearchBookingsCommand searchCommand = new( _bookingService, startDate, endDate, categoryName );
                searchCommand.Execute();
                break;

            default:
                Console.WriteLine( "Unknown command." );
                break;
        }
    }

    private static DateTime ParseDate( string str, string errorMsg = "Invalid date for booking." )
    {
        if ( DateTime.TryParse( str, out DateTime date ) )
        {
            return date;
        }

        throw new ArgumentException( errorMsg );
    }

    private static int ParseInt( string str, string errorMsg = "Invalid num" )
    {
        if ( int.TryParse( str, out int num ) )
        {
            return num;
        }

        throw new ArgumentException( errorMsg );
    }

    private static Guid ParseBookingId( string str )
    {
        if ( Guid.TryParse( str, out Guid id ) )
        {
            return id;
        }

        throw new ArgumentException( "Incorrect booking id for booking" );
    }
}
