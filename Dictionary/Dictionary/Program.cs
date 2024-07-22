const string dictionaryName = "dictionary.txt";

Dictionary<string, List<string>> dictionary = ReadDictionaryFromFile( dictionaryName );

bool isWorking = true;

PrintMenu();

while ( isWorking )
{
    Console.Write( "Enter command: " );
    string command = Console.ReadLine();
    switch ( command )
    {
        case "translate":
            TranslateWord( ref dictionary );
            break;
        case "add":
            AddWord( ref dictionary );
            break;
        case "finish":
            SaveDictionaryToFile( dictionaryName, dictionary );
            isWorking = false;
            break;
        case "help":
            PrintMenu();
            break;
        default:
            Console.WriteLine( "Unknown command" );
            break;
    }
}

static void PrintMenu()
{
    Console.WriteLine( "Command menu:" );
    Console.WriteLine( "add - Add a new word to the dictionary" );
    Console.WriteLine( "translate - Translate the word" );
    Console.WriteLine( "finish - Finish work" );
    Console.WriteLine( "help - Show command menu" );
}

static string GetWord()
{
    Console.Write( "Enter word: " );

    while ( true )
    {
        string str = Console.ReadLine().ToLower();

        if ( string.IsNullOrWhiteSpace( str ) )
        {
            Console.WriteLine( "You entered an incorrect word. Please enter the word again" );
            continue;
        }

        return str;
    }
}

static string GetTranslation()
{
    Console.Write( "Enter translation: " );

    while ( true )
    {
        string str = Console.ReadLine().Trim().ToLower();

        if ( string.IsNullOrWhiteSpace( str ) )
        {
            Console.WriteLine( "You entered an incorrect translation. Please enter the translation again" );
            continue;
        }

        return str;
    }
}

static void PrintListOfWords( List<string> words )
{
    for ( int i = 0; i <= words.Count - 1; i++ )
    {
        Console.Write( words[ i ] );

        if ( i != words.Count - 1 )
        {
            Console.Write( ", " );
        }
    }
    Console.WriteLine();
}

static List<string> GetTranslationsForRussianWord( Dictionary<String, List<String>> dictionary, string word )
{
    List<string> translations = new List<string>();

    foreach ( var wordWithTranslations in dictionary )
    {
        if ( wordWithTranslations.Value.Contains( word ) )
        {
            translations.Add( wordWithTranslations.Key );
        }
    }

    return translations;
}

static void SuggestAddingWordToDictionary( ref Dictionary<String, List<String>> dictionary, string word )
{
    Console.WriteLine( "This word is not in the dictionary. Do you want to add this word to the dictionary? " +
        "Enter \"yes\" if you want to add" );

    if ( !string.Equals( Console.ReadLine(), "yes", StringComparison.OrdinalIgnoreCase ) )
    {
        return;
    }

    string translation = GetTranslation();
    string successfulAdditionMsg = "The word was successfully added to the dictionary";

    if ( dictionary.ContainsKey( word ) )
    {
        dictionary[ word ].Add( translation );
    }
    else
    {
        dictionary[ word ] = new List<string> { translation };
    }

    Console.WriteLine( successfulAdditionMsg );
}

static void TranslateWord( ref Dictionary<String, List<String>> dictionary )
{
    string word = GetWord();

    if ( dictionary.ContainsKey( word ) )
    {
        PrintListOfWords( dictionary[ word ] );
        return;
    }

    List<string> translations = GetTranslationsForRussianWord( dictionary, word );
    if ( translations.Count != 0 )
    {
        PrintListOfWords( translations );
        return;
    }

    SuggestAddingWordToDictionary( ref dictionary, word );
}

static void AddWordAndTranslationToDictionary(
    ref Dictionary<String, List<String>> dictionary,
    string word,
    string translation )
{
    if ( dictionary[ word ].Contains( translation ) )
    {
        Console.WriteLine( "This word with translation is already contained in the dictionary" );
        return;
    }
    dictionary[ word ].Add( translation );
    Console.WriteLine( "This word with translation has been successfully added to the dictionary" );
}

static void AddWord( ref Dictionary<String, List<String>> dictionary )
{
    string word = GetWord();
    string translation = GetTranslation();

    if ( dictionary.ContainsKey( word ) )
    {
        AddWordAndTranslationToDictionary( ref dictionary, word, translation );
    }
    else if ( dictionary.ContainsKey( translation ) )
    {
        AddWordAndTranslationToDictionary( ref dictionary, translation, word );
    }
    else
    {
        dictionary[ word ] = new List<String>() { translation };
        Console.WriteLine( "This word with translation has been successfully added to the dictionary" );
    }
}

static Dictionary<string, List<string>> ReadDictionaryFromFile( string dictionaryName )
{
    Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    if ( !File.Exists( dictionaryName ) )
    {
        return dictionary;
    }

    StreamReader reader = new StreamReader( dictionaryName );

    while ( !reader.EndOfStream )
    {
        string line = reader.ReadLine();
        if ( line.Length == 0 )
        {
            continue;
        }
        string[] wordWithTranslations = line.Split( " - " );
        if ( wordWithTranslations.Length != 2 )
        {
            continue;
        }
        string englishWord = wordWithTranslations[ 0 ];
        List<string> translations = wordWithTranslations[ 1 ].Split( " | " ).ToList();
        dictionary[ englishWord ] = translations;
    }

    reader.Close();

    return dictionary;
}

void SaveDictionaryToFile( string dictionaryName, Dictionary<string, List<string>> dictionary )
{
    if ( !File.Exists( dictionaryName ) )
    {
        FileStream fs = File.Create( dictionaryName );
        fs.Close();
    }

    StreamWriter writer = new StreamWriter( dictionaryName );

    foreach ( var word in dictionary )
    {
        if ( word.Value.Count == 0 )
        {
            continue;
        }
        string str = word.Key + " - ";

        for ( int i = 0; i <= word.Value.Count - 1; i++ )
        {
            str += word.Value[ i ];
            if ( i != word.Value.Count - 1 )
            {
                str += " | ";
            }
        }
        writer.WriteLine( str );
    }

    writer.Close();
}