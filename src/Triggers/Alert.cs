namespace OpenWeatherMap.Triggers
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenWeatherMap.Converters;

    public sealed class Alert
    {
        [JsonRequired, JsonProperty("conditions")]
        public IReadOnlyCollection<TriggerAlert> Conditions { get; internal set; }

        [JsonRequired, JsonProperty("coordinates")]
        [JsonConverter(typeof(DefaultJsonConverter))]
        public Coordinates Coordinates { get; internal set; }

        [JsonRequired, JsonProperty("data")]
        public DateTimeOffset Date { get; internal set; }

        [JsonRequired, JsonProperty("last_update")]
        public DateTimeOffset LastUpdate { get; internal set; }
    }
}