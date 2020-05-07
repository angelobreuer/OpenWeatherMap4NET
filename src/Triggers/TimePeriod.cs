using Newtonsoft.Json;

namespace OpenWeatherMap.Triggers
{
    public sealed class TimePeriod
    {
        [JsonRequired, JsonProperty("start")]
        public TimeExpression Start { get; internal set; }

        [JsonRequired, JsonProperty("end")]
        public TimeExpression End { get; internal set; }
    }
}