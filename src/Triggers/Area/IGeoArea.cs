namespace OpenWeatherMap.Triggers.Area
{
    using Newtonsoft.Json;
    using OpenWeatherMap.Converters;

    [JsonConverter(typeof(GeoAreaJsonConverter))]
    public interface IGeoArea
    {
        GeoAreaType Type { get; }
    }
}