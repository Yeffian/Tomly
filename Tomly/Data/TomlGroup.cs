namespace Tomly.Data;

/// <summary>
/// A TOML group which stores all the properties in the group.
/// <remarks>
/// Syntax for a TOML group is:
/// [groupName]
/// property1 = value
/// property2 = value
/// etc
/// </remarks>
/// </summary>
public class TomlGroup
{
    /// <summary>
    /// The name of the TOML group.
    /// </summary>
    public string GroupName { get; private set; }
    
    /// <summary>
    /// All the TOML properties inside the group. 
    /// </summary>
    public List<TomlProperty> Properties { get; private set; }

    public TomlGroup(string groupName, List<TomlProperty> properties)
    {
        GroupName = groupName;
        Properties = properties;
    }

    public TomlGroup(string groupName)
    {
        GroupName = groupName;
        Properties = new List<TomlProperty>();
    }
}