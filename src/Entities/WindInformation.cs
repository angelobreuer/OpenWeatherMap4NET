namespace OpenWeatherMap.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    ///     The strongly-typed representation of a JSON-object providing wind information.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WindInformation
    {
        /// <summary>
        ///     Gets the angle of the wind direction.
        /// </summary>
        /// <value>the angle of the wind direction.</value>
        [JsonProperty("deg")]
        public double? Direction { get; internal set; }

        /// <summary>
        ///     Gets the wind speed.
        /// </summary>
        /// <value>the wind speed.</value>
        [JsonProperty("speed")]
        public double? Speed { get; internal set; }

        /// <summary>
        ///     Builds a <see cref="string"/> representation of the object.
        /// </summary>
        /// <returns>the string representation</returns>
        public override string ToString() => $"speed: {Speed}, deg: {Direction}";
    }
}
