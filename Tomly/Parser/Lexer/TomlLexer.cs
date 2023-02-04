using Tomly.Data;

namespace Tomly.Parser.Lexer;

public class TomlLexer
{
    private UnparsedTomlDocument _source;
    private float _current;

    private char Current => _source.CharacterAt(_current);

    public TomlLexer(UnparsedTomlDocument source)
    {
        _source = source;
    }

    public List<TomlToken> ProduceTokens()
    {
        // TODO: create token list and identify all the tokens
        return null;
    }
}