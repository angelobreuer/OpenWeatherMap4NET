namespace OpenWeatherMap.Triggers
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public sealed class TriggerInformation : Trigger
    {
        [JsonRequired, JsonProperty("alerts")]
        public IReadOnlyDictionary<string, TriggerAlert> Alerts { get; internal set; }
    }
}