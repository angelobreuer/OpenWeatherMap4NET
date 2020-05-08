namespace OpenWeatherMap.Triggers.Area
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeoAreaType : byte
    {
        Point,
        MultiPoint,
        Polygon,
        MultiPolygon
    }
}