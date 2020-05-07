namespace OpenWeatherMap.Triggers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public sealed class AlertTrigger : Trigger
    {
        [JsonRequired, JsonProperty("alerts")]
        public IReadOnlyDictionary<string, Alert> Alerts { get; internal set; }
        [JsonProperty("history_alerts")]
        public IReadOnlyDictionary<string, HistoryAlert> HistoryAlerts { get; internal set; }
    }
}