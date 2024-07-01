string productName = GetNameOfProduct();
uint productQuantity = GetQuantityOfProduct();
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

string GetNameOfProduct()
{
    Console.Write( "Введите название продукта:" );
    string nameOfProduct = GetName( "Вы ввели некорректное название продукта!!! Введите название еще раз, пожалуйста!" );
    return nameOfProduct;
}

uint GetQuantityOfProduct()
{
    Console.Write( "Введите количество товаров:" );
    bool isQuantityReceived = false;
    uint quantity = 0;

    while ( !isQuantityReceived )
    {
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
        isQuantityReceived = true;
    }

    return quantity;
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
    Console.WriteLine( $"Здравствуйте, {username}, вы заказали {productQuantity} {productName} на адрес {address}, все верно?" );
    string answer = Console.ReadLine();
    if ( answer.ToLower() == "да" )
    {
        DateTime dateWithTime = DateTime.Today.AddDays( 3 );
        DateOnly date = DateOnly.FromDateTime( dateWithTime );
        Console.WriteLine( $"{username}! Ваш заказ {productName} в количестве {productQuantity} оформлен! Ожидайте доставку по адресу {address} к {date}" );
    }
    else
    {
        Console.WriteLine( "Заказ отменен" );
    }
}