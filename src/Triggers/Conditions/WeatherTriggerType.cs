namespace OpenWeatherMap.Triggers.Conditions
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WeatherTriggerName : byte
    {
        [EnumMember(Value = "temp")]
        Temperature,

        [EnumMember(Value = "pressure")]
        Pressure,

        [EnumMember(Value = "humidity")]
        Humidity,

        [EnumMember(Value = "wind_speed")]
        WindSpeed,

        [EnumMember(Value = "wind_direction")]
        WindDirection,

        [EnumMember(Value = "clouds")]
        Clouds
    }
}