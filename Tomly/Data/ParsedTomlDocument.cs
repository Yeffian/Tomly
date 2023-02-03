using System.Text;

namespace Tomly.Data;

/// <summary>
/// The fully parsed representation of a TOML file, which stores object representations
/// of all the data.
/// </summary>
public class ParsedTomlDocument
{
    /// <summary>
    /// All the TOML groups in the document.
    /// </summary>
    public List<TomlGroup> Groups { get; private set; }

    public ParsedTomlDocument(List<TomlGroup> groups)
    {
        Groups = groups;
    }
    
    public ParsedTomlDocument()
    {
        Groups = new List<TomlGroup>();
    }

    /// <summary>
    /// Adds a new group to the TOML data.
    /// </summary>
    /// <param name="group">The group to add</param>
    public void AddGroup(TomlGroup group) => Groups.Add(group);

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        foreach (TomlGroup group in Groups)
        {
            builder.AppendLine($"[{group.GroupName}]");
            
            foreach (TomlProperty property in group.Properties)
            {
                builder.AppendLine($"{property.Key} = {property.Value}");
            }

            builder.Append("\n");
        }
        
        return builder.ToString();
    }
}