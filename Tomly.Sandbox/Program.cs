// See https://aka.ms/new-console-template for more information

using Tomly.Data;
using Tomly.Serialization;

var serverGroup = new TomlGroup("server");
serverGroup.Properties.Add(new("port", 8080, typeof(int)));
serverGroup.Properties.Add(new("hostname", "idk.lol", typeof(string)));
serverGroup.Properties.Add(new("admin", "yeff", typeof(string)));
serverGroup.Properties.Add(new("ssl", true, typeof(bool)));

var devGroup = new TomlGroup("dev");
devGroup.Properties.Add(new("venv", false, typeof(bool)));
devGroup.Properties.Add(new("authors", "yis", typeof(string)));

var tomlObject = new ParsedTomlDocument();
tomlObject.AddGroup(serverGroup);
tomlObject.AddGroup(devGroup);

var data = TomlSerializer.Serialize(tomlObject);
File.WriteAllText("C:\\Users\\aditc\\dev\\Tomly\\Tomly.Sandbox\\test.toml", data);