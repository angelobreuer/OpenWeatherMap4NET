namespace OpenWeatherMap.Triggers.Time
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimestampExpression : byte
    {
        [EnumMember(Value = "exact")]
        Exact,

        [EnumMember(Value = "after")]
        After,

        [EnumMember(Value = "before")]
        Before
    }
}