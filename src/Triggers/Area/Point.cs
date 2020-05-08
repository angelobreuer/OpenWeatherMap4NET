namespace OpenWeatherMap.Triggers.Area
{
    using Newtonsoft.Json;

    public sealed class Point : IGeoArea
    {
        public Point(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        [JsonConstructor]
        internal Point()
        {
        }

        [JsonRequired, JsonProperty("coordinates")]
        public Coordinates Coordinates { get; internal set; }

        /// <inheritdoc/>
        [JsonRequired, JsonProperty("type")]
        public GeoAreaType Type => GeoAreaType.Point;
    }
}