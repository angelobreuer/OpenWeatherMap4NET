namespace OpenWeatherMap.Triggers.Time
{
    using Newtonsoft.Json;

    public sealed class TimePeriod
    {
        [JsonRequired, JsonProperty("end")]
        public DynamicTimestamp End { get; internal set; }

        [JsonRequired, JsonProperty("start")]
        public DynamicTimestamp Start { get; internal set; }
    }
}