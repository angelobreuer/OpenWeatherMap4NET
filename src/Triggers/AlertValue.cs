using Newtonsoft.Json;

namespace OpenWeatherMap.Triggers
{
    public sealed class AlertValue
    {
        [JsonRequired, JsonProperty("min")]
        public double MinValue { get; internal set; }

        [JsonRequired, JsonProperty("max")]
        public double MaxValue { get; internal set; }
    }
}