using Newtonsoft.Json;

namespace OpenWeatherMap.Triggers
{
    public sealed class AlertCondition
    {
        [JsonRequired, JsonProperty("current_value")]
        public AlertValue Value { get; internal set; }

        [JsonRequired, JsonProperty("condition")]
        public TriggerCondition Condition { get; internal set; }
    }
}