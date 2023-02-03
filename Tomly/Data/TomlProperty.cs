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
    
    public TomlProperty(string key, object value)
    {
        Key = key;
        Value = value;
    }
}