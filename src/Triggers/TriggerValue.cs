namespace OpenWeatherMap.Triggers
{
    using Newtonsoft.Json;

    public readonly struct TriggerValue
    {
        [JsonConstructor]
        public TriggerValue([JsonProperty("min")] float min, [JsonProperty("max")] float max)
        {
            Min = min;
            Max = max;
        }

        public float Min { get; }
        public float Max { get; }
    }
}