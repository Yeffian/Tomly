using System.Text;
using Tomly.Data;

namespace Tomly.Parser.Lexer;

public class TomlLexer
{
    private UnparsedTomlDocument _source;
    private int _current;
    private int _start;

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
            case var _ when char.IsWhiteSpace(Current):
                _current++;
                return new TomlToken(TomlTokenType.Whitespace, " ", typeof(string));
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
        StringBuilder ident = new();

        bool charClause = Char.IsLetter(Peek(1));
        
        while (charClause && !AtEnd)
        {
            if (Current != '=')
            {
                ident.Append(Current);
                _current++;
            }
            else
            {
                break;
            }
        }

        return ident.ToString();
    }

    private string ProduceValueString()
    {
        _current++;
        StringBuilder value = new();

        while (Current != '"' && !AtEnd)
        {
            value.Append(Current);
            _current++;
        }

        _current++;
        
        return value.ToString();
    }
}