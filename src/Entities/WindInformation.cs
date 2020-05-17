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
        [JsonProperty("deg")]
        public double? Direction { get; internal set; }

        /// <summary>
        ///     Gets the wind speed.
        /// </summary>
        [JsonProperty("speed")]
        public double? Speed { get; internal set; }

        /// <summary>
        ///     Builds a string representation of the object.
        /// </summary>
        /// <returns>the string representation</returns>
        public override string ToString() => $"speed: {Speed}, deg: {Direction}";
    }
}