namespace OpenWeatherMap.Triggers.Area
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public sealed class MultiPolygon : IGeoArea
    {
        public MultiPolygon(IReadOnlyCollection<IReadOnlyCollection<IReadOnlyCollection<Coordinates>>> coordinates)
        {
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        }

        public MultiPolygon(params Coordinates[][][] coordinates)
        {
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        }

        [JsonConstructor]
        internal MultiPolygon()
        {
        }

        /// <inheritdoc/>
        [JsonRequired, JsonProperty("coordinates")]
        public IReadOnlyCollection<IReadOnlyCollection<IReadOnlyCollection<Coordinates>>> Coordinates { get; internal set; }

        /// <inheritdoc/>
        [JsonRequired, JsonProperty("type")]
        public GeoAreaType Type => GeoAreaType.Polygon;
    }
}