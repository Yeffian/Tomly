namespace Tomly.Parser.Lexer;

public class TomlToken
{
    public TomlTokenType Type { get; private set; }
    
    public object Lexeme { get; private set; }

    public Type LexemeType { get; private set; }

    public TomlToken(TomlTokenType type, object lexeme, Type lexemeType)
    {
        Type = type;
        Lexeme = lexeme;
        LexemeType = lexemeType;
    }
}