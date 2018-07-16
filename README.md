# MiniConfig
small and easy configuration tool for .net applications

var config = new IrConfig();

config.AddOrUpdate("port", "1580");

if (config.TryGet("port", out int port))
{
    Console.Write(port);
}
