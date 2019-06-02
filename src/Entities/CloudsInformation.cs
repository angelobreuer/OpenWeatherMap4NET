namespace OpenWeatherMap.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    ///     The strongly-typed representation of a JSON-object providing clouds information.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class CloudsInformation
    {
        /// <summary>
        ///     Gets the cloudiness in percent (%).
        /// </summary>
        [JsonProperty("all")]
        public double Cloudiness { get; internal set; }

        /// <summary>
        ///     Gets the cloudiness today in percent (%).
        /// </summary>
        [JsonProperty("today")]
        public double TodayCloudiness { get; internal set; }
    }
}