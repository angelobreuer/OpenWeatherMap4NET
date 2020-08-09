namespace OpenWeatherMap.Entities
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///     The strongly-typed representation of a JSON-object providing weather condition information.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WeatherCondition
    {
        /// <summary>
        ///     Gets the description of the weather (localized).
        /// </summary>
        /// <value>the description of the weather (localized).</value>
        [JsonRequired, JsonProperty("description")]
        public string Description { get; internal set; } = null!;

        /// <summary>
        ///     Gets the weather icon id (e.g. 09d).
        /// </summary>
        /// <value>the weather icon id (e.g. 09d).</value>
        [JsonRequired, JsonProperty("icon")]
        public string IconId { get; internal set; } = null!;

        /// <summary>
        ///     Gets the URL to the weather icon.
        /// </summary>
        /// <value>the URL to the weather icon.</value>
        public string IconUrl => $"http://openweathermap.org/img/w/{IconId}.png";

        /// <summary>
        ///     Gets the identifier of the weather condition.
        /// </summary>
        /// <value>the identifier of the weather condition.</value>
        [JsonRequired, JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        ///     Gets the type of the weather condition.
        /// </summary>
        /// <value>the type of the weather condition.</value>
        [JsonRequired, JsonProperty("main")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WeatherConditionType Type { get; internal set; }
    }
}
