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
        ///     The calculation time needed.
        /// </summary>
        [JsonProperty("dt"), JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset? CalculationTime { get; internal set; }

        /// <summary>
        ///     The weathers in the list.
        /// </summary>
        [JsonRequired, JsonProperty("list")]
        public IReadOnlyCollection<Weather> List { get; internal set; }
    }
}