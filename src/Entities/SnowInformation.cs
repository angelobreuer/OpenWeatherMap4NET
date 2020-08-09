namespace OpenWeatherMap.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    ///     The strongly-typed representation of a JSON-object providing snow information.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class SnowInformation
    {
        /// <summary>
        ///     Gets the snow volume the last 3 hours in mm.
        /// </summary>
        /// <value>the snow volume the last 3 hours in mm.</value>
        [JsonProperty("3h")]
        public double? VolumeLast3Hours { get; internal set; }

        /// <summary>
        ///     Gets the snow volume the last hour in mm.
        /// </summary>
        /// <value>the snow volume the last hour in mm.</value>
        [JsonProperty("1h")]
        public double? VolumeLastHour { get; internal set; }
    }
}
