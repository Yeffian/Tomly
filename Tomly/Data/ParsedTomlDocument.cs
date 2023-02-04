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
    
    public ParsedTomlDocument(params TomlGroup[] groups)
    {
        Groups = groups.ToList();
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
}