namespace OpenWeatherMap.Entities
{
    using System;
    using Newtonsoft.Json;
    using OpenWeatherMap.Util;

    /// <summary>
    ///     The strongly-typed representation of a JSON-object providing additional weather
    ///     information for a weather station (e.g. sunrise, sunset).
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class AdditionalWeatherInformation
    {
        /// <summary>
        ///     Gets the time when the sun rises.
        /// </summary>
        [JsonProperty("sunrise")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset? Sunrise { get; internal set; }

        /// <summary>
        ///     Gets the time when the sun goes down.
        /// </summary>
        [JsonProperty("sunset")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset? Sunset { get; internal set; }

        /// <summary>
        ///     Gets the country code (e.g. "GB").
        /// </summary>
        [JsonProperty("country")]
        public string CountryCode { get; internal set; }
    }
}