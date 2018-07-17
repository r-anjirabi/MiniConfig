# MiniConfig
small and easy configuration tool for .net applications

Let's create a sample setting.conf

```xml
<?xml version='1.0' encoding='utf-8'?>
<configuration>
  <appSettings>
    <add key='host' value='www.host.com' />
  </appSettings>
</configuration>
```
## Example

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
