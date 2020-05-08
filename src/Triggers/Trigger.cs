namespace OpenWeatherMap.Triggers
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenWeatherMap.Triggers.Area;
    using OpenWeatherMap.Triggers.Conditions;
    using OpenWeatherMap.Triggers.Time;

    public class Trigger
    {
        [JsonProperty("area")]
        public IReadOnlyCollection<IGeoArea> Areas { get; internal set; }

        [JsonProperty("conditions")]
        public IReadOnlyCollection<TriggerCondition> Conditions { get; internal set; }

        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; internal set; }

        [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
        public string OwnerId { get; internal set; }

        [JsonRequired, JsonProperty("time_period")]
        public TimePeriod Period { get; internal set; }
    }
}