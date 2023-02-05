namespace Tomly.Data;

/// <summary>
/// A unparsed representation of a TOML file to store file content and other information.
/// </summary>
public class UnparsedTomlDocument
{
    public UnparsedTomlDocument(string path)
    {
        Content = File.ReadAllText(path);
        LOC = File.ReadAllLines(path).Length;
    }
    
    /// <summary>
    /// All the content in the file.
    /// </summary>
    public string Content { get; private set; }
    
    /// <summary>
    /// Lines of TOML code.
    /// </summary>
    public int LOC { get; private set; }

    public char CharacterAt(float location) => Content[(int) location];

    public float Length() => Content.Length;
}