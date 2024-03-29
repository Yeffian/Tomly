﻿// See https://aka.ms/new-console-template for more information

using Tomly.Data;
using Tomly.Serialization;

var serverGroup = new TomlGroup("server");
serverGroup.AddProperties(
    TomlProperty.CreateProperty("port", 8080),
    TomlProperty.CreateProperty("hostname", "idk.lol"),
    TomlProperty.CreateProperty("admin", "yeff"),
    TomlProperty.CreateProperty("ssl", true)
);


var devGroup = new TomlGroup("dev");
devGroup.AddProperties(
    TomlProperty.CreateProperty("venv", false),
    TomlProperty.CreateProperty("authors", "yis")
);

var tomlObject = new ParsedTomlDocument(serverGroup, devGroup);

var data = TomlSerializer.Serialize(tomlObject);
File.WriteAllText("C:\\Users\\aditc\\dev\\Tomly\\Tomly.Sandbox\\test.toml", data);