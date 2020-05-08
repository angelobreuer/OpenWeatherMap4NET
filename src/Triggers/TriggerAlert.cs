namespace OpenWeatherMap.Triggers
{
    using Newtonsoft.Json;
    using OpenWeatherMap.Triggers.Conditions;

    public sealed class TriggerAlert
    {
        [JsonRequired, JsonProperty("condition")]
        public TriggerCondition Condition { get; internal set; }

        [JsonRequired, JsonProperty("current_value")]
        public TriggerValue Value { get; internal set; }
    }
}