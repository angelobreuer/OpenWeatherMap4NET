namespace OpenWeatherMap.Triggers
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Trigger
    {
        [JsonRequired, JsonProperty("conditions")]
        public IReadOnlyCollection<TriggerCondition> Conditions { get; internal set; }

        [JsonRequired, JsonProperty("time_period")]
        public TimePeriod TimePeriod { get; internal set; }

        [JsonProperty("_id")]
        public string Id { get; internal set; }
    }
}