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
                string identifier = ProduceKeyString();
                return new TomlToken(TomlTokenType.Key, identifier, typeof(string));
            case var _ when Current == '"':
                string value = ProduceValueString();
                return new TomlToken(TomlTokenType.Value, value, typeof(string));
            default:
                _current++;
                return new TomlToken(TomlTokenType.Bad, " ", typeof(string));
        }
    }

    public IEnumerable<TomlToken> ProduceTokens()
    {
        // TODO: create token list and identify all the tokens
        while (!AtEnd)
        {
            var token = ProduceToken();
            yield return token;
        }
    }

    private string ProduceKeyString()
    {
        string ident = "";

        bool charClause = Char.IsLetter(Peek(1));
        
        while (charClause && !AtEnd)
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

    private string ProduceValueString()
    {
        _current++;
        string value = "";

        while (Current != '"' && !AtEnd)
        {
            value += Current;
            _current++;
        }

        _current++;
        
        return value;
    }
}