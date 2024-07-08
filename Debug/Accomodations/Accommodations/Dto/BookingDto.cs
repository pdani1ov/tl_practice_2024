namespace Accommodations.Dto;

public class BookingDto
{
    //Добавил конструктор с проверкой корректности startDate и endDate
    public BookingDto(
        int userId,
        string category,
        DateTime startDate,
        DateTime endDate,
        CurrencyDto currency )
    {
        if ( startDate >= endDate )
        {
            throw new ArgumentException( "The start date cannot be later than or equal to the end date" );
        }
        if ( startDate <= DateTime.Now )
        {
            throw new ArgumentException( "Start date cannot be earlier than now date" );
        }
        _userId = userId;
        _startDate = startDate;
        _endDate = endDate;
        _category = category;
        _currency = currency;
    }

    private int _userId;
    private DateTime _startDate;
    private DateTime _endDate;
    private string _category;
    private CurrencyDto _currency;

    public int UserId { get => _userId; }
    public DateTime StartDate { get => _startDate; }
    public DateTime EndDate { get => _endDate; }
    public string Category { get => _category; }
    public CurrencyDto Currency { get => _currency; }
}
