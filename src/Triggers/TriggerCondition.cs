namespace OpenWeatherMap.Triggers
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public sealed class TriggerCondition
    {
        [JsonRequired, JsonProperty("name")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FieldType Name { get; internal set; }

        [JsonRequired, JsonProperty("expression")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExpressionType Expression { get; internal set; }

        [JsonRequired, JsonProperty("amount")]
        public double Amount { get; internal set; }
    }
}