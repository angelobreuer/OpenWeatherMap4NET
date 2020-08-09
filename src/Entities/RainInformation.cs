namespace OpenWeatherMap.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    ///     The strongly-typed representation of a JSON-object providing rain information.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class RainInformation
    {
        /// <summary>
        ///     Gets the rain volume the last 3 hours in mm.
        /// </summary>
        /// <value>the rain volume the last 3 hours in mm.</value>
        [JsonProperty("3h")]
        public double? VolumeLast3Hours { get; internal set; }

        /// <summary>
        ///     Gets the rain volume the last hour in mm.
        /// </summary>
        /// <value>the rain volume the last hour in mm.</value>
        [JsonProperty("1h")]
        public double? VolumeLastHour { get; internal set; }
    }
}
