// See https://aka.ms/new-console-template for more information

using Tomly.Data;

var serverGroup = new TomlGroup("server");
serverGroup.Properties.Add(new("port", 8080));
serverGroup.Properties.Add(new("hostname", "idk.lol"));
serverGroup.Properties.Add(new("admin", "yeff"));
serverGroup.Properties.Add(new("ssl", true));

var devGroup = new TomlGroup("dev");
devGroup.Properties.Add(new("venv", false));
devGroup.Properties.Add(new("authors", "yis"));

var tomlObject = new ParsedTomlDocument();
tomlObject.AddGroup(serverGroup);
tomlObject.AddGroup(devGroup);

Console.WriteLine(tomlObject.ToString());
