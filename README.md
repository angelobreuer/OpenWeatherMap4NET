# OpenWeatherMap4NET

![Logo](https://i.imgur.com/YGidHLe.png)

## `Getting Started`

1. First install [.NET Core >= 2.0](https://dotnet.microsoft.com/download/dotnet-core/2.0) for your platform.
2. Install the [OpenWeatherMap4NET](https://www.nuget.org/packages/OpenWeatherMap4NET/) NuGet Package.
3. Request an API key from [openweathermap.org](https://home.openweathermap.org/api_keys)

___

## `Usage Example`

Here is a short usage example for using the service to request the temperature information for 'London':

```csharp
// build the service
var service = new OpenWeatherMapService(new OpenWeatherMapOptions
{
    ApiKey = "[INSERT OPENWEATHERMAP.ORG TOKEN HERE]"
});

// set global unit to Metric, so temperatures are in Celsius and speed units in meter/sec.
RequestOptions.Default.Unit = UnitType.Metric;

// request weather information for "London"
var weather = await service.GetCurrentWeatherAsync("London");

// print out current temperature
Console.WriteLine(weather.Temperature.Value); // -> 20,4
```

___

## `Dependencies`
- [System.Runtime.Caching](https://www.nuget.org/packages/System.Runtime.Caching/) *(used for internal request caching)*
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) *(used for HTTP payload deserialization)*