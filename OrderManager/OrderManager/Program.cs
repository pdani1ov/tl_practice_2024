string productName = GetProductName();
uint productQuantity = GetProductQuantity();
string username = GetUserName();
string address = GetAddress();
ConfirmOrder( productName, productQuantity, username, address );

string GetName( string errorMsg )
{
    string str = Console.ReadLine();
    while ( string.IsNullOrWhiteSpace( str ) )
    {
        Console.WriteLine( errorMsg );
        str = Console.ReadLine();
    }
    return str;
}

string GetProductName()
{
    Console.Write( "Введите название продукта:" );
    string nameOfProduct = GetName( "Вы ввели некорректное название продукта!!! Введите название еще раз, пожалуйста!" );
    return nameOfProduct;
}

uint GetProductQuantity()
{
    Console.Write( "Введите количество товаров:" );

    while ( true )
    {
        uint quantity = 0;
        if ( uint.TryParse( Console.ReadLine(), out uint @uint ) )
        {
            quantity = @uint;
        }
        else
        {
            Console.WriteLine( "Вы ввели некорректное значение! Введите количество товаров еще раз, пожалуйста!" );
            continue;
        }
        if ( quantity == 0 )
        {
            Console.WriteLine( "Количество товаров не может быть равно 0!!! Введите количество товаров еще раз, пожалуйста!" );
            continue;
        }
        if ( quantity > uint.MaxValue )
        {
            Console.WriteLine( "Вы ввели некорректное количество товаров!!! Введите количество товаров еще раз, пожалуйста!" );
            continue;
        }
        return quantity;
    }
}

string GetUserName()
{
    Console.Write( "Введите свое имя:" );
    string username = GetName( "Вы ввели некорректное имя!!! Введите имя еще раз, пожалуйста!" );
    return username;
}

string GetAddress()
{
    Console.Write( "Введите свой адрес:" );
    string address = GetName( "Вы ввели некорректный адрес!!! Введите свой адрес еще раз, пожалуйста!" );
    return address;
}

void ConfirmOrder( string productName, uint productQuantity, string username, string address )
{
    const string positiveAnswer = "да";

    Console.WriteLine( $"Здравствуйте, {username}, вы заказали {productQuantity} " +
        $"{productName} на адрес {address}, все верно?(Введите \"да\", если вы согласны)" );
    string answer = Console.ReadLine();
    if ( string.Equals( answer, positiveAnswer, StringComparison.OrdinalIgnoreCase ) )
    {
        DateTime dateWithTime = DateTime.Today.AddDays( 3 );
        DateOnly date = DateOnly.FromDateTime( dateWithTime );
        Console.WriteLine( $"{username}! Ваш заказ {productName} в количестве {productQuantity} оформлен! " +
            $"Ожидайте доставку по адресу {address} к {date}" );
    }
    else
    {
        Console.WriteLine( "Заказ отменен" );
    }
}