using System.Text;
using Tomly.Data;

namespace Tomly.Serialization;

public static class TomlSerializer
{
    public static string Serialize(ParsedTomlDocument doc)
    {
        StringBuilder builder = new StringBuilder();
        
        foreach (TomlGroup group in doc.Groups)
        {
            builder.AppendLine($"[{group.GroupName}]");
            
            foreach (TomlProperty property in group.Properties)
            {
                builder.Append($"{property.Key} = ");

                if (property.Type == typeof(string))
                {
                    builder.AppendLine($"\"{property.Value}\"");
                }
                if (property.Type == typeof(float) || property.Type == typeof(int))
                {
                    builder.AppendLine($"{property.Value}");
                }
                if (property.Type == typeof(bool))
                {
                    string result = (bool)property.Value ? "true" : "false";
                    builder.AppendLine(result);
                }
            }

            builder.Append("\n");
        }

        return builder.ToString();
    }
}