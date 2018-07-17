# MiniConfig
small and easy configuration tool for .net applications

### 1. Install NuGet Package

```
Install-Package miniconfig
```

### 2. Create a sample setting.conf

```xml
<?xml version='1.0' encoding='utf-8'?>
<configuration>
  <appSettings>
    <add key='host' value='www.host.com' />
  </appSettings>
</configuration>
```

### 3. Enable copy to bin folder

Enable copy to bin folder for setting.conf

```csharp
var config = new MiniConfig("setting.conf");

if (config.TryGet("host", out string host))
{
    Console.Write(host);
}

config.AddOrUpdate("port", "1580");

if (config.TryGet("port", out int port)) // if config exist
{
    Console.Write(port);
}
````
if you don't have configurations at startup you don't need create setting.conf:

```c#
var config = new MiniConfig();

config.AddOrUpdate("port", "1580");

if (config.TryGet("port", out int port)) // if config exist
{
    Console.Write(port);
}
```
