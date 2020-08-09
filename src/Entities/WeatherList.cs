namespace OpenWeatherMap.Entities
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenWeatherMap.Util;

    /// <summary>
    ///     The response object for weather lists.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WeatherList
    {
        /// <summary>
        ///     Gets the calculation time needed.
        /// </summary>
        /// <value>the calculation time needed.</value>
        [JsonProperty("dt"), JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset? CalculationTime { get; internal set; }

        /// <summary>
        ///     Gets the weathers in the list.
        /// </summary>
        /// <value>the weathers in the list.</value>
        [JsonRequired, JsonProperty("list")]
        public IReadOnlyCollection<Weather> List { get; internal set; } = Array.Empty<Weather>();
    }
}
