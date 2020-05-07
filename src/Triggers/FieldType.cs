namespace OpenWeatherMap.Triggers
{
    using System.Runtime.Serialization;

    public enum FieldType
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