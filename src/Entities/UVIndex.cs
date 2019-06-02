namespace OpenWeatherMap.Entities
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using OpenWeatherMap.Util;

    /// <summary>
    ///     Represents the response object for the UV-api.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class UVIndex : WeatherCoordinates
    {
        /// <summary>
        ///     Gets the when the UV index is.
        /// </summary>
        [JsonRequired, JsonProperty("date")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset DateTime { get; internal set; }

        /// <summary>
        ///     Gets the UV index.
        /// </summary>
        [JsonRequired, JsonProperty("value")]
        public double Value { get; internal set; }

        /// <summary>
        ///     Builds a string representation of the object.
        /// </summary>
        /// <returns>the string representation</returns>
        public override string ToString() => $"{base.ToString()}, index: {Value}, date: {DateTime.ToString(CultureInfo.InvariantCulture)}";
    }
}