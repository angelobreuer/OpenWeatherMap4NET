namespace OpenWeatherMap.Triggers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public sealed class HistoryAlert : Alert
    {
        [JsonRequired, JsonProperty("owner")]
        public string UserId { get; internal set; }

        [JsonRequired, JsonProperty("triggerId")]
        public string TriggerId { get; internal set; }
    }
}