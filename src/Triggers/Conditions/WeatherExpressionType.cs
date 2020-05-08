namespace OpenWeatherMap.Triggers.Conditions
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WeatherExpressionType : byte
    {
        [EnumMember(Value = "$gt")]
        GreaterThan,

        [EnumMember(Value = "$lt")]
        LessThan,

        [EnumMember(Value = "$gte")]
        GreaterThanOrEqual,

        [EnumMember(Value = "$lte")]
        LessThanOrEqual,

        [EnumMember(Value = "$eq")]
        Equal,

        [EnumMember(Value = "$ne")]
        NotEqual
    }
}