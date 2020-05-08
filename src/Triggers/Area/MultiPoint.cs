namespace OpenWeatherMap.Triggers.Area
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenWeatherMap.Converters;

    public sealed class MultiPoint : IGeoArea
    {
        public MultiPoint(IReadOnlyCollection<Coordinates> coordinates)
        {
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        }

        public MultiPoint(params Coordinates[] coordinates)
        {
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        }

        [JsonConstructor]
        internal MultiPoint()
        {
        }

        /// <inheritdoc/>
        [JsonRequired, JsonProperty("coordinates")]
        public IReadOnlyCollection<Coordinates> Coordinates { get; internal set; }

        /// <inheritdoc/>
        [JsonRequired, JsonProperty("type")]
        public GeoAreaType Type => GeoAreaType.MultiPoint;
    }
}