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
        case "show":
            PrintMenu();
            break;
        default:
            Console.WriteLine( "Unknown command" );
            break;
    }
}

void PrintMenu()
{
    Console.WriteLine( "Command menu:" );
    Console.WriteLine( "add - Add a new word to the dictionary" );
    Console.WriteLine( "translate - Translate the word" );
    Console.WriteLine( "finish - Finish work" );
    Console.WriteLine( "show - Show command menu" );
}

bool IsRussianLanguage( string word )
{
    foreach ( char ch in word )
    {
        if ( ( ch < 'а' || ch > 'я' ) && ( ch < 'А' || ch > 'Я' ) )
        {
            return false;
        }
    }

    return true;
}

bool IsEnglishLanguage( string word )
{
    foreach ( char ch in word )
    {
        if ( ( ch < 'a' || ch > 'z' ) && ( ch < 'A' || ch > 'Z' ) )
        {
            return false;
        }
    }

    return true;
}

string GetWord()
{
    Console.Write( "Enter word: " );

    bool hasCorrectWord = false;
    string word = "";

    while ( !hasCorrectWord )
    {
        string str = Console.ReadLine().ToLower();

        if ( string.IsNullOrWhiteSpace( str ) )
        {
            Console.WriteLine( "You entered an incorrect word. Please enter the word again" );
            continue;
        }

        if ( IsEnglishLanguage( str ) || IsRussianLanguage( str ) )
        {
            hasCorrectWord = true;
            word = str;
        }
        else
        {
            Console.WriteLine( "You entered a word in an unknown language. Please enter the word again" );
        }
    }

    return word;
}

string GetTranslation( bool isEnglishWord )
{
    Console.Write( "Enter translation: " );

    bool hasCorrectTranslate = false;
    string translation = "";

    while ( !hasCorrectTranslate )
    {
        string str = Console.ReadLine();

        if ( string.IsNullOrWhiteSpace( str ) )
        {
            Console.WriteLine( "You entered an incorrect translation. Please enter the translation again" );
            continue;
        }

        if ( isEnglishWord && IsRussianLanguage( str ) )
        {
            hasCorrectTranslate = true;
            translation = str.ToLower();
        }
        else if ( !isEnglishWord && IsEnglishLanguage( str ) )
        {
            hasCorrectTranslate = true;
            translation = str.ToLower();
        }
        else
        {
            Console.WriteLine( "Language of translation is incorrect. Please enter the translation again" );
        }
    }

    return translation;
}

void PrintListOfWords( List<string> words )
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

List<string> GetTranslationsForRussianWord( Dictionary<String, List<String>> dictionary, string word )
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

void SuggestAddingWordToDictionary( ref Dictionary<String, List<String>> dictionary, string word, bool isEnglishWord )
{
    Console.WriteLine( "This word is not in the dictionary. Do you want to add this word to the dictionary? Enter \"yes\" if you want to add" );

    if ( Console.ReadLine() != "yes" )
    {
        return;
    }

    string translation = GetTranslation( isEnglishWord );
    string successfulAdditionMsg = "The word was successfully added to the dictionary";

    if ( isEnglishWord )
    {
        dictionary[ word ] = new List<string>() { translation };
        Console.WriteLine( successfulAdditionMsg );
        return;
    }

    if ( dictionary.ContainsKey( translation ) )
    {
        dictionary[ translation ].Add( word );
        Console.WriteLine( successfulAdditionMsg );
        return;
    }

    dictionary[ translation ] = new List<string>() { word };
    Console.WriteLine( successfulAdditionMsg );
}

void TranslateWord( ref Dictionary<String, List<String>> dictionary )
{
    string word = GetWord();
    bool isEnglishWord = IsEnglishLanguage( word );

    if ( isEnglishWord )
    {
        if ( dictionary.ContainsKey( word ) )
        {
            PrintListOfWords( dictionary[ word ] );
            return;
        }
    }
    else
    {
        List<string> translations = GetTranslationsForRussianWord( dictionary, word );
        if ( translations.Count != 0 )
        {
            PrintListOfWords( translations );
            return;
        }
    }

    SuggestAddingWordToDictionary( ref dictionary, word, isEnglishWord );
}

void AddWordAndTranslationToDictionary( ref Dictionary<String, List<String>> dictionary, bool isEnglishWord, string word, string translation )
{
    if ( !dictionary.ContainsKey( word ) )
    {
        dictionary[ word ] = new List<String>() { translation };
        return;
    }

    if ( dictionary[ word ].Contains( translation ) )
    {
        Console.WriteLine( "This word with translation is already contained in the dictionary" );
    }

    dictionary[ word ].Add( translation );
    Console.WriteLine( "This word with translation has been successfully added to the dictionary" );
}

void AddWord( ref Dictionary<String, List<String>> dictionary )
{
    string word = GetWord();
    bool isEnglishWord = IsEnglishLanguage( word );
    string translation = GetTranslation( isEnglishWord );
    if ( isEnglishWord )
    {
        AddWordAndTranslationToDictionary( ref dictionary, isEnglishWord, word, translation );
    }
    else
    {
        AddWordAndTranslationToDictionary( ref dictionary, isEnglishWord, translation, word );
    }
}

Dictionary<string, List<string>> ReadDictionaryFromFile( string dictionaryName )
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
        File.Create( dictionaryName );
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