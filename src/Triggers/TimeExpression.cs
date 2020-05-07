namespace OpenWeatherMap.Triggers
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using OpenWeatherMap.Util;

    public sealed class TimeExpression
    {
        [JsonRequired, JsonProperty("expression")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TimeExpressionType ExpressionType { get; internal set; }

        [JsonRequired, JsonProperty("amount")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset Value { get; internal set; }
    }
}