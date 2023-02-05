using Tomly.Data;

namespace Tomly.Parser.Lexer;

public class TomlLexer
{
    private UnparsedTomlDocument _source;
    private float _current;
    private float _start;

    private char Current => _source.CharacterAt(_current);

    private char Peek(int increment) => _source.CharacterAt(_current + increment);

    private bool AtEnd => _current >= _source.Length();

    public TomlLexer(UnparsedTomlDocument source)
    {
        _source = source;
    }

    private TomlToken ProduceToken()
    {
        switch (Current)
        {
            case '=':
                _current++;
                return new TomlToken(TomlTokenType.Equals, "=", typeof(string));
            case var _ when char.IsLetter(Current):
                _current++;
                string identifier = ProduceKeyString();
                return new TomlToken(TomlTokenType.Key, identifier, typeof(string));
            // case var _ when Current == '"':
            //     string value = ProduceValueString();
            //     return new TomlToken(TomlTokenType.Value, value, typeof(string));
            default:
                _current++;
                return new TomlToken(TomlTokenType.Bad, " ", typeof(string));
        }
    }

    public IEnumerable<TomlToken> ProduceTokens()
    {
        while (!AtEnd)
        {
            var token = ProduceToken();
            yield return token;
        }
    }

    private string ProduceKeyString()
    {
        string ident = "";

        while (Char.IsLetter(Peek(1)) && !AtEnd)
        {
            if (Current != '=')
            {
                ident += Current;
                _current++;
            }
            else
            {
                break;
            }
        }

        return ident;
    }
    
    // private string ProduceValueString()
    // {
    //     string value = "";
    //
    //     while (Char.IsLetter(Peek(1)) && !AtEnd)
    //     {
    //         if (Current != '"')
    //         {
    //             value += Current;
    //             _current++;
    //         }
    //         else
    //         {
    //             break;
    //         }
    //     }
    //     
    //     return value;
    // }
}