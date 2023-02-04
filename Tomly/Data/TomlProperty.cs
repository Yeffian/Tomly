namespace Tomly.Data;

/// <summary>
/// Represents a TOML property with a key and a value of any type.
/// </summary>
public class TomlProperty
{
    /// <summary>
    /// The property key.
    /// </summary>
    public string Key { get; private set; }
    
    /// <summary>
    /// The property value of any type.
    /// </summary>
    public object Value { get; private set; }
    
    /// <summary>
    /// The type of the property value.
    /// </summary>
    public Type Type { get; private set; }
    
    private TomlProperty(string key, object value, Type type)
    {
        Key = key;
        Value = value;
        Type = type;
    }

    public static TomlProperty CreateProperty<T>(string key, T value)
    {
        var type = value.GetType();

        return new TomlProperty(key, value, type);
    }
}