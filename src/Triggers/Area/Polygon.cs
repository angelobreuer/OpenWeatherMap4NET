namespace OpenWeatherMap.Triggers.Area
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public sealed class Polygon : IGeoArea
    {
        public Polygon(IReadOnlyCollection<IReadOnlyCollection<Coordinates>> coordinates)
        {
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        }

        public Polygon(params Coordinates[][] coordinates)
        {
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        }

        [JsonConstructor]
        internal Polygon()
        {
        }

        /// <inheritdoc/>
        [JsonRequired, JsonProperty("coordinates")]
        public IReadOnlyCollection<IReadOnlyCollection<Coordinates>> Coordinates { get; internal set; }

        /// <inheritdoc/>
        [JsonRequired, JsonProperty("type")]
        public GeoAreaType Type => GeoAreaType.Polygon;
    }
}