namespace OpenWeatherMap.Triggers
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenWeatherMap.Entities;
    using OpenWeatherMap.Util;

    public class Alert
    {
        [JsonRequired, JsonProperty("conditions")]
        public IReadOnlyCollection<AlertCondition> Conditions { get; internal set; }

        [JsonRequired, JsonProperty("date")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset Date { get; internal set; }

        [JsonRequired, JsonProperty("last_update")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset LastUpdate { get; internal set; }

        [JsonRequired, JsonProperty("coordinates")]
        public WeatherCoordinates Coordinates { get; internal set; }
    }
}