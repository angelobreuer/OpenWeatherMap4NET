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
        ///     Gets the identifier of the weather condition.
        /// </summary>
        [JsonRequired, JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        ///     Gets the type of the weather condition.
        /// </summary>
        [JsonRequired, JsonProperty("main")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WeatherConditionType Type { get; internal set; }

        /// <summary>
        ///     Gets the description of the weather (localized).
        /// </summary>
        [JsonRequired, JsonProperty("description")]
        public string Description { get; internal set; }

        /// <summary>
        ///     Gets the weather icon id (e.g. 09d).
        /// </summary>
        [JsonRequired, JsonProperty("icon")]
        public string IconId { get; internal set; }

        /// <summary>
        ///     Gets the URL to the weather icon.
        /// </summary>
        [JsonIgnore]
        public string IconUrl => $"http://openweathermap.org/img/w/{IconId}.png";
    }
}